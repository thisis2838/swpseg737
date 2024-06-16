using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics;
using System.Reflection;

namespace HoaLacLaptopShop.Helpers
{
    public static class DBContextHelpers
    {
        public static void FillForeignKeys<T>(this DbContext context, T instance)
        {
            var entType = context.Model.FindEntityType(typeof(T).FullName!);
            if (entType is null) throw new Exception($"Type {typeof(T)} not present in context.");

            var foreignKeys = entType.GetForeignKeys();
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var foreignKey in foreignKeys)
            {
                Trace.Assert(foreignKey.Properties.Count == 1);
                var foreignKeyProp = foreignKey.Properties.First().PropertyInfo!;
                var keyValueProp = props.FirstOrDefault(x => x == foreignKeyProp);
                if (keyValueProp is null) throw new Exception("Couldn't find foreign key property in type.");
                var keyValue = keyValueProp.GetValue(instance);
                if (keyValue is null) continue;

                var foreignValue = context.Find(foreignKey.PrincipalEntityType.ClrType, keyValue);
                var foreignProp = props.FirstOrDefault(x => x.PropertyType == foreignKey.PrincipalEntityType.ClrType);
                if (foreignProp is null) throw new Exception("Couldn't find foreign property in type.");

                foreignProp.SetValue(instance, foreignValue);
            }
        }
    }
}
