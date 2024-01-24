using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;

public class AddHeaderParameter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
            operation.Parameters = new List<OpenApiParameter>();

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "UserNo",
            In = ParameterLocation.Header,
            Required = false,
            Description = "User Number"
        });

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "UserToken",
            In = ParameterLocation.Header,
            Required = false,
            Description = "JWT Token"
        });
    }
}