using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Azure.WebApi.Core.Sample.Swagger
{
    public class OperationGenericItemsFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            // Adding Swagger Responses
            var swaggerResponseAttributes = context.ApiDescription.ControllerAttributes().Union(context.ApiDescription.ActionAttributes()).OfType<SwaggerResponseAttribute>().ToList();

            if (swaggerResponseAttributes.All(r => r.StatusCode != (int)HttpStatusCode.BadRequest))
                operation.Responses.Add(((int)HttpStatusCode.BadRequest).ToString(), new Response { Description = "Bad Request. Missing mandatory parameter" });

            if (swaggerResponseAttributes.All(r => r.StatusCode != (int)HttpStatusCode.Unauthorized))
                operation.Responses.Add(((int)HttpStatusCode.Unauthorized).ToString(), new Response { Description = "Authentication failure" });

            if (swaggerResponseAttributes.All(r => r.StatusCode != (int)HttpStatusCode.Forbidden))
                operation.Responses.Add(((int)HttpStatusCode.Forbidden).ToString(), new Response { Description = "Authorization failure" });

            if (swaggerResponseAttributes.All(r => r.StatusCode != (int)HttpStatusCode.InternalServerError))
                operation.Responses.Add(((int)HttpStatusCode.InternalServerError).ToString(), new Response { Description = "Internal server error" });
        }
    }
}
