using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApi;
using MinimalApi.Route;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();


var contacts = new List<MinimalApi.MyContact>()
{
    new MinimalApi.MyContact(){Id=1, Name="Name1"},
    new MinimalApi.MyContact(){Id=2, Name="Name2"}
};

app.MapGet("/contact", async (HttpContext context) =>
{

    var contact= contacts;

    await context.Response.WriteAsync(JsonSerializer.Serialize(contact));
});
//GET /products/{id}
app.MapGet("/contact/{id:int}", async (HttpContext context, int id) =>
{
    MyContact? contact = contacts.FirstOrDefault(temp => temp.Id == id);
    if (contact == null)
    {
        context.Response.StatusCode = 400; //Bad Request
        await context.Response.WriteAsync("Incorrect Product ID");
        return;
    }

    await context.Response.WriteAsync(JsonSerializer.Serialize(contact));
});

app.MapPut("/contact", async (HttpContext context, MinimalApi.MyContact con) =>
{

    contacts.Add(con);
    await context.Response.WriteAsync("Recorded Added");
    
});


var mapGroup = app.MapGroup("/product");

List<Product> products = new List<Product>() {
 new Product() { Id = 1, ProductName = "Smart Phone" },
 new Product() { Id = 2, ProductName = "Smart TV" }
};

//GET /products
mapGroup.MapGet("/", async (HttpContext context) => {
    //Sample Response:
    //[{ "Id": 1, "ProductName": "Smart Phone" }, { "Id": 2, "ProductName": "Smart TV" }]

    await context.Response.WriteAsync(JsonSerializer.Serialize(products));
});
//GET /products/{id}
mapGroup.MapGet("/{id:int}", async (HttpContext context, int id) =>
{
    Product? product = products.FirstOrDefault(temp => temp.Id == id);
    if (product == null)
    {
        context.Response.StatusCode = 400; //Bad Request
        await context.Response.WriteAsync("Incorrect Product ID");
        return;
    }

    await context.Response.WriteAsync(JsonSerializer.Serialize(product));
});
//POST /products
mapGroup.MapPost("/", async (HttpContext context, Product product) => {
    products.Add(product);
    await context.Response.WriteAsync("Product Added");
});



var mapGroupEmp = app.MapGroup("/employee").EmployeeApi();



app.Run();


