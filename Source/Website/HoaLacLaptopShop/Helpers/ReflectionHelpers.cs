using System.Reflection;
using System.Runtime.CompilerServices;

namespace HoaLacLaptopShop.Helpers
{
    public static class ReflectionHelpers
    {
        /// <summary>
        /// Fills the properties of the current object with those of the same name of the target object.
        /// </summary>
        /// <typeparam name="E">The type of the current object</typeparam>
        /// <typeparam name="T">The type of the target object</typeparam>
        /// <param name="obj">The current object</param>
        /// <param name="otherObj">The target object</param>
        /// <param name="include">The names of the properties to copy over</param>
        /// <param name="exclude">The names of the properties to avoid copying over</param>
        public static void FillFromOther<E, T>
        (
            this E obj, T otherObj,
            IEnumerable<string>? include = null, IEnumerable<string>? exclude = null
        )
            where T : class
            where E : class
        {
            var thisProps = typeof(E).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.CanWrite && x.CanRead).ToArray();
            var otherProps = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.CanWrite && x.CanRead).ToArray();

            foreach (var prop in thisProps)
            {
                if (include != null && !include.Contains(prop.Name)) continue;
                if (exclude != null && exclude.Contains(prop.Name)) continue;

                var otherProp = otherProps.FirstOrDefault(x => x.Name == prop.Name && x.PropertyType == prop.PropertyType);
                if (otherProp != null) prop.SetValue(obj, otherProp.GetValue(otherObj));
            }
        }

    }
}
