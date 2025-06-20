using NJsonSchema;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

namespace Accounting.Api.Configuration
{
    public class CustomSchemaDocumentProcessor : IDocumentProcessor
    {
        public void Process(DocumentProcessorContext context)
        {
            var modifiedSchemas = new Dictionary<string, JsonSchema>();

            foreach (var schema in context.Document.Definitions)
            {
                string originalName = schema.Key;
                string newName = GetShortSchemaName(originalName);

                if (newName != originalName && !modifiedSchemas.ContainsKey(newName))
                {
                    modifiedSchemas[newName] = schema.Value;
                }
            }

            // Remove old keys and add new renamed schemas
            foreach (var schema in modifiedSchemas)
            {
                context.Document.Definitions.Remove(schema.Key);
                context.Document.Definitions[schema.Key] = schema.Value;
            }
        }

        private string GetShortSchemaName(string originalName)
        {
            return originalName
                .Replace("Accounting", "")
                .Replace("Api", "")
                .Replace("Features", "")
                .Replace("AccountApiEntities", "")
                .Replace("AccountingApiFeatures", "")
                .Trim();
        }
    }
}