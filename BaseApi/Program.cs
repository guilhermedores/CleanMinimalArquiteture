var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddBaseAuth();
builder.Services.AddBaseConfig();
builder.Services.AddDataBaseConfig();
builder.Services.AddAutoMapperConfig();

#region Services DI

builder.Services.AddCustomerService();

#endregion


var app = builder.Build();

app.UseBaseConfig();
app.UseBaseAuth();

app.MapRouteCustomer();

app.Run();