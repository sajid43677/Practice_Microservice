/*using Microsoft.AspNetCore.Mvc;
using ProductService.Utilities;
using GraphQL;
using GraphQL.Types;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    public class GraphQLProductController : Controller
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecuter;
        public GraphQLProductController(ISchema schema, 
            IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var variables = query.Variables?.ToObject<Dictionary<string, object?>>();

            var inputs = variables?.ToInputs();
            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                In
            };

        }
    }
}*/
