using System;
using System.Reflection;

namespace LibrarySystem.Data.Models.core
{
    public static class TypeExtensions
    {
        public static PropertyInfo GetPropertyByNameInsensitive(this Type instance, string propName)
        {

            if (string.IsNullOrWhiteSpace(propName)) return null;

            return instance.GetProperty(propName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        }
    }
}
