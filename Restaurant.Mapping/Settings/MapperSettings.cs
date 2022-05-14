using System.Reflection;

namespace Restaurant.Mapping.Settings
{
    public static class MapperSettings
    {
        public static Assembly[] CurrentDomainAssemblies = AppDomain.CurrentDomain.GetAssemblies();
    }
}
