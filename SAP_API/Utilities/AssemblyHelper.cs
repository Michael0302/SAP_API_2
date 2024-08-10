using System.Reflection;

namespace SAP_API.Utilities
{
    public class AssemblyHelper
    {
        public static IEnumerable<string> GetSAPAssemblyAllTypes()
        {
            var sapLibName = "SAP_WSDL_Library";
            var assembly = Assembly.Load(sapLibName);
            var types = assembly.GetTypes().Select(t => t.FullName ?? "");
            return types;
        }
        public static IEnumerable<string> GetQADAssemblyAllTypes()
        {
            var sapLibName = "QAD_WSDL_Library";
            var assembly = Assembly.Load(sapLibName);
            var types = assembly.GetTypes().Select(t => t.FullName ?? "");
            return types;
        }
        public static IEnumerable<string> GetAssemblyAllTypes()
        {
            var list = GetSAPAssemblyAllTypes().ToList();
            list.AddRange(GetQADAssemblyAllTypes());
            return list;
        }
    }
}
