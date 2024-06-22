using System.IO;
using System.Linq;
using System.Text;

namespace HoaLacLaptopShop.Services
{
    /// <summary>
    /// Accessors and modifiers for the host's local resources.
    /// These methods ensure access does not spill onto other parts of the file system outside the content root.
    /// </summary>
    public interface ILocalResourceService
    {
        /// <summary>
        /// Gets the full file path from the given path fragments.
        /// </summary>
        public string GetFullPath(params string[] paths);
        /// <summary>
        /// Gets the full file path from the given resource type and path fragments.
        /// </summary>
        public string GetFullPath(ResourceType type, params string[] paths);
        /// <summary>
        /// Gets the relative path to the content root from the given path fragments.
        /// </summary>
        public string GetRelativePath(params string[] paths);
        /// <summary>
        /// Gets the relative path to the content root from the given resource type and path fragments.
        /// </summary>
        public string GetRelativePath(ResourceType type, params string[] paths);
        /// <summary>
        /// Gets the relative path to the content root from the given path.
        /// </summary>
        public string GetParentDirectory(string path);

        /// <summary>
        /// Creates or opens a new file for reading/writing at the given path.
        /// </summary>
        public FileStream FileOpen(string path);
        /// <summary>
        /// Creates or opens a new file at the given path, then writes the text into that file.
        /// </summary>
        public void FileWriteAll(string path, string text);
        /// <summary>
        /// Creates or opens a new file at the given path, then reads all the text stored in that file.
        /// </summary>
        public string FileReadAll(string path);

        /// <summary>
        /// Copies a file.
        /// </summary>
        public void FileCopy(string from, string to);
        /// <summary>
        /// Checks if a given file exists or not.
        /// </summary>
        public bool FileExists(string path);
        /// <summary>
        /// Moves a file.
        /// </summary>
        public void FileMove(string from, string to);
        /// <summary>
        /// Removes a file.
        /// </summary>
        public void FileRemove(string path);

        /// <summary>
        /// Creates a new directory if one hasn't already existed.
        /// </summary>
        public void DirectoryCreate(string path);
        /// <summary>
        /// Checks if a given directory exists or not.
        /// </summary>
        public bool DirectoryExists(string path);
        /// <summary>
        /// Removes a directory.
        /// </summary>
        public void DirectoryRemove(string path);
        /// <summary>
        /// Gets the relative paths of all the files in a directory.
        /// </summary>
        public string[] DirectoryFiles(string path, string? searchPattern = null, SearchOption? option = null);
    }

    public class LocalResourceService : ILocalResourceService
    {
        private const StringSplitOptions SPLIT_OPTIONS = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
        private static char DirectorySeparator => Path.DirectorySeparatorChar;
        private static char VolumeSeparator => Path.VolumeSeparatorChar;

        private readonly IWebHostEnvironment _environment;
        private string WebRoot => _environment.WebRootPath.TrimEnd('\\');

        public LocalResourceService(IWebHostEnvironment env)
        {
            _environment = env;
        }

        private static string[] SplitPath(string path)
        {
            path = path.Replace('/', DirectorySeparator);
            return path.Split(DirectorySeparator, SPLIT_OPTIONS);
        }
        private static string SanitizePath(string path, bool canContainDriveLetter = true)
        {
            path = path.Replace('/', DirectorySeparator);
            var elems = SplitPath(path).ToList();
            for (int i = 0; i < elems.Count;)
            {
                if (elems[i] == ".")
                {
                    elems.RemoveAt(i);
                    continue;
                }
                if (i < elems.Count - 1 && elems[i] != ".." && elems[i + 1] == "..")
                {
                    elems.RemoveAt(i + 1);
                    elems.RemoveAt(i);
                    continue;
                }
                if (Path.GetInvalidFileNameChars().Any(elems[i].Contains))
                {
                    if (Path.GetInvalidFileNameChars().Contains(VolumeSeparator))
                    {
                        if (i == 0 && elems[i].EndsWith(VolumeSeparator) && canContainDriveLetter)
                            goto end;
                    }
                    throw new ArgumentException("Invalid character found in path.");
                }

                end:;
                i++;
            }
            return string.Join(DirectorySeparator, elems.ToArray());
        }
        private static string ResourceTypeToName(ResourceType type)
        {
            return type.ToString().ToLower();
        }

        public string GetRelativePath(params string[] paths)
        {
            var elems = paths
                .Where(x => x != null)
                .SelectMany((x, i) =>
                {
                    x = SanitizePath(x, i == 0);
                    if (i == 0)
                    {
                        if (x.StartsWith(WebRoot, StringComparison.InvariantCultureIgnoreCase))
                        {
                            x = x.Substring(WebRoot.Length);
                        }
                        else
                        {
                            var first = SplitPath(x).FirstOrDefault();
                            if (first != null && first.EndsWith(Path.VolumeSeparatorChar))
                            {
                                throw new InvalidOperationException("Tried to access a location outside the content root.");
                            }
                        }
                    }

                    var split = SplitPath(x);
                    return split;
                })
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToArray();

            for (int i = 0, level = 0; i < elems.Length; i++)
            {
                level += elems[i] == ".." ? -1 : 1;
                if (level < 0) throw new AccessBeyondContentRootException();
            }

            return DirectorySeparator + string.Join(DirectorySeparator, elems);
        }
        public string GetRelativePath(ResourceType type, params string[] paths)
        {
            return GetRelativePath(paths.Prepend(ResourceTypeToName(type)).ToArray());
        }
        public string GetParentDirectory(string path)
        {
            var elems = SplitPath(GetRelativePath(path));
            if (elems.Length == 0) return "";
            return GetRelativePath(elems.Take(elems.Length - 1).ToArray());
        }
        public string GetFullPath(params string[] paths)
        {
            return WebRoot + GetRelativePath(paths);
        }
        public string GetFullPath(ResourceType type, params string[] paths)
        {
            return GetFullPath(paths.Prepend(ResourceTypeToName(type)).ToArray());
        }
        

        public FileStream FileOpen(string path)
        {
            DirectoryCreate(path);
            return File.Create(GetFullPath(path));
        }
        public void FileWriteAll(string path, string text)
        {
            using (var file = new StreamWriter(FileOpen(path), Encoding.UTF8))
            {
                file.Write(text);
            }
        }
        public string FileReadAll(string path)
        {
            return File.ReadAllText(GetFullPath(path));
        }

        public bool FileExists(string path)
        {
            return File.Exists(GetFullPath(path));
        }
        public void FileMove(string from, string to)
        {
            DirectoryCreate(GetParentDirectory(to));
            File.Move(GetFullPath(from), GetFullPath(to));
        }
        public void FileCopy(string from, string to)
        {
            DirectoryCreate(GetParentDirectory(to));
            File.Copy(GetFullPath(from), GetFullPath(to));
        }
        public void FileRemove(string path)
        {
            path = GetFullPath(path);
            if (File.Exists(path)) File.Delete(path);
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(GetFullPath(path));
        }
        public void DirectoryCreate(string path)
        {
            path = GetFullPath(path);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }
        public void DirectoryRemove(string path)
        {
            Directory.Delete(GetFullPath(path), true);
        }
        public string[] DirectoryFiles(string path, string? searchPattern = null, SearchOption? option = null)
        {
            var full = GetFullPath(path);
            return Directory.Exists(full)
                ? []
                : Directory
                    .EnumerateFiles(full, searchPattern ?? "*.*", option ?? SearchOption.AllDirectories)
                    .Select((x) => GetRelativePath(x))
                    .ToArray();
        }
    }

    public class AccessBeyondContentRootException : Exception
    {
        public AccessBeyondContentRootException() : base("Tried to access content beyond the content root.") 
        { }
    }
    public enum ResourceType
    {
        Image,
        Html,
        Temp
    }
}
