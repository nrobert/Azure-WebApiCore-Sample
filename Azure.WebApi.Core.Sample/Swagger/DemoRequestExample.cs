using Swashbuckle.AspNetCore.Examples;

namespace Azure.WebApi.Core.Sample.Swagger
{
    public class DemoRequestExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new DemoRequest()
            {
                Id = "123",
                Lang = "fr-FR",
                Username = "testeur"
            };
        }
    }
}
