using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Templating;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;

namespace HoaLacLaptopShop.Services
{
    public interface ITemporaryResourceService
    {
        public string GetRelativePath(string id);
        public string GetRelativePath(TemporaryResource resource);
        public TemporaryResource? Get(string id);
        public IEnumerable<TemporaryResource> GetAll(string? bag = null);
        public TemporaryResource Add(byte[] data, string bag, string? extension);
        public TemporaryResource Add(Stream data, string bag, string? extension);
        public void Remove(string id);
        public void Remove(TemporaryResource resource);
        public void RemoveAll(string? bag = null);
        public bool Verify(string id);
        public bool Verify(TemporaryResource resource);
        public IEnumerable<bool> VerifyAll(string? bag = null);
        public string Move(string id, string destination);
        public string Move(TemporaryResource resource, string destination);
        public IEnumerable<string> MoveAll(string? bag, string destination);
    }

    public class TemporaryResourceService : ITemporaryResourceService
    {
        private readonly IHttpContextAccessor _ctxAccessor;
        private readonly ILocalResourceService _local;
        private readonly TemporaryResourceContext _context;
        private HttpContext HttpContext => _ctxAccessor.HttpContext!;

        public TemporaryResourceService
        (
            ILocalResourceService local, 
            IHttpContextAccessor httpContext,
            TemporaryResourceContext dbContext
        )
        {
            _ctxAccessor = httpContext;
            _local = local;
            _context = dbContext;
            _local.DirectoryCreate(_local.GetRelativePath(ResourceType.Temp));
        }
        public string GetRelativePath(string id)
        {
            var resource = _context.Resources.AsNoTracking().FirstOrDefault(x => x.ID == id);
            return resource is null ? "" : GetRelativePath(resource);
        }
        public string GetRelativePath(TemporaryResource resource)
        {
            return _local.GetRelativePath(ResourceType.Temp, resource.ID + resource.Extension);
        }

        public TemporaryResource? Get(string id)
        {
            return _context.Resources.AsNoTracking().FirstOrDefault(x => x.ID == id);
        }
        public IEnumerable<TemporaryResource> GetAll(string? bag = null)
        {
            var user = HttpContext.GetCurrentUserID()!.Value;
            var get = _context.Resources.AsNoTracking().Where(x => x.UploaderID == user);
            if (bag != null) get = get.Where(x => x.Bag == bag);
            return get.ToList();
        }

        public TemporaryResource Add(byte[] data, string bag, string? extension)
        {
            using (var stream = new MemoryStream(data))
            {
                return Add(stream, bag, extension);
            }
        }
        public TemporaryResource Add(Stream data, string bag, string? extension)
        {
            var id = ResourceHelper.GenerateResourceToken();
            extension = (extension is null ? "" : ("." + extension.TrimStart('.')));
            var name = id + extension;
            bag ??= "";

            using (var file = _local.FileOpen(_local.GetRelativePath(ResourceType.Temp, name)))
            {
                data.CopyTo(file);
            }

            var resource = new TemporaryResource()
            {
                ID = id,
                UploaderID = HttpContext.GetCurrentUserID()!.Value,
                Bag = bag,
                Extension = extension,
                Length = data.Length
            };
            _context.Resources.Add(resource);
            _context.SaveChanges();
            return resource;
        }

        private void RemoveFromDatabase(TemporaryResource resource)
        {
            var user = HttpContext.GetCurrentUserID()!.Value;
            if (resource.UploaderID != user)
            {
                throw new Exception("Not allowed to remove this resource!");
            }
            _context.Resources.Remove(resource);
            _context.SaveChanges();
        }
        public void Remove(TemporaryResource resource)
        {
            RemoveFromDatabase(resource);
            _local.FileRemove(GetRelativePath(resource));
        }
        public void Remove(string id)
        {
            var resource = _context.Resources.AsNoTracking().First(x => x.ID == id);
            if (resource != null) Remove(resource);
        }
        public void RemoveAll(string? bag = null)
        {
            foreach (var resource in GetAll(bag)) Remove(resource);
        }

        public bool Verify(TemporaryResource resource)
        {
            if (!_local.FileExists(GetRelativePath(resource)))
            {
                RemoveFromDatabase(resource);
                return false;
            }
            return true;
        }
        public bool Verify(string id)
        {
            var resource = Get(id);
            if (resource is null) return false;
            return Verify(resource);
        }
        public IEnumerable<bool> VerifyAll(string? bag = null)
        {
            foreach (var resource in GetAll(bag))
                yield return Verify(resource);
        }

        public string Move(TemporaryResource resource, string destination)
        {
            RemoveFromDatabase(resource);
            var newPath = _local.GetRelativePath(destination, resource.GetFileName());
            _local.FileMove(GetRelativePath(resource), newPath);
            return newPath;
        }
        public string Move(string id, string destination)
        {
            var resource = _context.Resources.AsNoTracking().First(x => x.ID == id);
            return Move(resource, destination);
        }
        public IEnumerable<string> MoveAll(string? bag, string destination)
        {
            foreach (var resource in GetAll(bag))
                yield return Move(resource, destination);
        }
    }
}
