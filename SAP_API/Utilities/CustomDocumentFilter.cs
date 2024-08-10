using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SAP_API.Configuration;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace SAP_API.Utilities
{
    public class CustomDocumentFilter : IDocumentFilter
    {
        private readonly IOptionsMonitor<Settings> _setting;

        public CustomDocumentFilter(IOptionsMonitor<Settings> settings)
        {
            _setting = settings;
        }

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            if (string.IsNullOrEmpty(_setting.CurrentValue.Swagger.DocumentFilter))
            {
                return;
            }
            var docKeys = _setting.CurrentValue.Swagger.DocumentFilter.Split(',');
            var keepPaths = docKeys.Select(x => $"/api/{x}").ToList();

            var pathsToRemove = swaggerDoc.Paths
                .Where(pathItem =>
                {

                    return !keepPaths.Any(x => pathItem.Key.StartsWith(x));
                })
                .ToList();


            foreach (var path in pathsToRemove)
            {
                swaggerDoc.Paths.Remove(path.Key);
            }

            var allTypeSet = new HashSet<string>();
            var allTypes = AssemblyHelper.GetAssemblyAllTypes().ToHashSet();

            foreach (var docKey in docKeys)
            {
                var sapLibName = $"{docKey}_WSDL_Library";
                var assembly = Assembly.Load(sapLibName);

                var types = assembly?.GetTypes()
                                         .Select(t => t.FullName);
                if(types != null)
                {
                    foreach (var t in types)
                    {
                        if (!string.IsNullOrEmpty(t))
                        {
                            allTypes.Remove(t);
                        }
                    }
                }
            }
            var schemasToRemove = swaggerDoc.Components.Schemas
                .Where(schemaItem =>
                {
                    return allTypes.Contains(schemaItem.Key);
                })
                .ToList();

            foreach (var schema in schemasToRemove)
            {
                swaggerDoc.Components.Schemas.Remove(schema.Key);
            }
        }
    }
}
