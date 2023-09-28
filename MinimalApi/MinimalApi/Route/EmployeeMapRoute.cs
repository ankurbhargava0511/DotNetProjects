using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace MinimalApi.Route
{
    public static class EmployeeMapRoute
    {
        public static List<Employee> employee = new List<Employee>() {
            new Employee() { Id = 1, Name = "Emp1" },
            new Employee() { Id = 2, Name = "Emp2" } };

        public static RouteGroupBuilder EmployeeApi(this RouteGroupBuilder builder)
        {

        builder.MapGet("/", async (HttpContext context) => {

                await context.Response.WriteAsync(JsonSerializer.Serialize(employee));
            });
            
        builder.MapGet("/{id:int}", async (HttpContext context, int id) =>
            {
                Employee? emp = employee.FirstOrDefault(temp => temp.Id == id);
                if (emp == null)
                {
                    context.Response.StatusCode = 400; //Bad Request
                    await context.Response.WriteAsync("Incorrect Employee ID");
                    return;
                }

                await context.Response.WriteAsync(JsonSerializer.Serialize(emp));
            });
           
        builder.MapPost("/", async (HttpContext context, Employee emp) => {
                employee.Add(emp);
                await context.Response.WriteAsync("Employee Added");
            })
                .AddEndpointFilter<CustomEndpointFilter>()

        .AddEndpointFilter(async (EndpointFilterInvocationContext context, EndpointFilterDelegate next) => {
        var emp = context.Arguments.OfType<Employee>().FirstOrDefault();

        if (emp == null)
        {
            return Results.BadRequest("Empoyee details are not found in the request");
        }

        var validationContext = new ValidationContext(emp);
        List<ValidationResult> errors = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(emp, validationContext, errors, true);

        if (!isValid)
        {
            return Results.BadRequest(errors.FirstOrDefault()?.ErrorMessage);
        }

        var result = await next(context); //invokes the subsequent endpoint filter or endpoint's request delegate

        //After logic here


        return result;
    })
    ;


            builder.MapPut("/{id}", async (HttpContext context, int id,Employee emp) => {

                Employee? emp1 = employee.FirstOrDefault(temp => temp.Id == id);
                if (emp1 == null)
                {
                    //context.Response.StatusCode = 400; //Bad Request
                    //await context.Response.WriteAsync("Incorrect Employee ID");
                    return Results.ValidationProblem( 
                         new Dictionary<string, string[]> {
                             { "Id", new string[]{ "Incorrect Employee ID" } } }
                        );
                }

                emp1.Name = emp.Name;

                return Results.Ok("Employee Added");
            });


            builder.MapDelete("/{id}", async (HttpContext context, int id) => {

                Employee? emp1 =   employee.FirstOrDefault(temp => temp.Id == id);
                if (emp1 == null)
                {
                    //context.Response.StatusCode = 400; //Bad Request
                    //await context.Response.WriteAsync("Incorrect Employee ID");
                    return Results.BadRequest("Incorrect Employee ID");
                }

                employee.Remove(emp1);

                return Results.Ok("Employee Deleted");
                //await context.Response.WriteAsync("Employee Added");
            });

            return builder;

        }
    }
}
