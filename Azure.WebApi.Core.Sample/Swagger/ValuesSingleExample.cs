using Swashbuckle.AspNetCore.Examples;

namespace Azure.WebApi.Core.Sample.Swagger
{
    public class ValuesSingleExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return "Sample String 1";
        }
    }
}
