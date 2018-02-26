using Swashbuckle.AspNetCore.Examples;

namespace Azure.WebApi.Core.Sample.Swagger
{
    public class ValuesMultipleExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
