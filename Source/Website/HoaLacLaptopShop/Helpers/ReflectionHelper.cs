using System.Reflection;

namespace HoaLacLaptopShop.Helpers
{
    public static class ReflectionHelper
    {
        public static void FillFromOther<E, T>(this E obj, T otherObj)
            where T : class
            where E : class
        {
            var thisProps = typeof(E).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CanWrite && x.CanRead).ToArray();
            var otherProps = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CanWrite && x.CanRead).ToArray();

            foreach (var prop in thisProps)
            {
                var otherProp = otherProps.FirstOrDefault(x => x.Name == prop.Name && x.PropertyType == prop.PropertyType);
                if (otherProp != null) prop.SetValue(obj, otherProp.GetValue(otherObj));
            }
        }
    }
}
