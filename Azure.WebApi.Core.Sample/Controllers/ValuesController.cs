using Azure.WebApi.Core.Sample.Swagger;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Examples;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Net;

namespace Azure.WebApi.Core.Sample.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        [SwaggerOperation("GetValues")]
        [SwaggerResponse((int)HttpStatusCode.OK, description: "The id of the created lead", type: typeof(IEnumerable<string>))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(ValuesMultipleExample))]
        [Produces("application/json")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [SwaggerOperation("GetValueById")]
        [SwaggerRequestExample(typeof(int), typeof(int))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(ValuesSingleExample))]
        [Produces("application/json")]
        public string Get(int id)
        {
            return "value";
        }
        
        [HttpPost]
        [SwaggerOperation("GetValueByDemoRequest")]
        [SwaggerRequestExample(typeof(DemoRequest), typeof(DemoRequestExample))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(ValuesSingleExample))]
        [Consumes("application/json")]
        [Produces("application/json")]
        public string Post([FromBody]DemoRequest demoRequest)
        {
            return demoRequest.Id;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [SwaggerOperation("PutValue")]
        [Consumes("application/json")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [SwaggerOperation("DeleteValue")]
        [SwaggerRequestExample(typeof(int), typeof(int))]
        public void Delete(int id)
        {
        }
    }
}
