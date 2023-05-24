using AutoMapper;

public static class CustomerService
{
    public static IServiceCollection AddCustomerService(this IServiceCollection services)
    {
        services.AddTransient<IBaseRepository<Customer>, BaseRepository<Customer>>();
        return services;
    }
}

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerRequests.Create, Customer>().ConstructUsing(c => new Customer(c.Name, c.Email, c.BirthDate));
    }
}

public static class CustomerController
{
    public static WebApplication MapRouteCustomer(this WebApplication app)
    {
        var name = "Customer";

        RouteGroupBuilder customerItens = app.MapGroup("/customer").WithTags(name).WithOpenApi();

        customerItens.MapGet("/", GetAll);
        customerItens.MapGet("/{id}", GetById);
        customerItens.MapPost("/", Create);
        customerItens.MapPut("/{id}", Update);
        customerItens.MapDelete("/{id}", Delete);       

        return app;
    }

    static async Task<IResult> GetAll(IBaseRepository<Customer> repository)
    {
        return Results.Ok(await repository.GetAll());
    }

    static async Task<IResult> GetById(Guid id, IBaseRepository<Customer> repository)
    {
        return Results.Ok(await repository.GetById(id));
    }

    static async Task<IResult> Create(CustomerRequests.Create obj, IBaseRepository<Customer> repository, IMapper mapper)
    {
        try
        {
            var mappedObj = mapper.Map<CustomerRequests.Create, Customer>(obj);
            var responseObj = await repository.Create(mappedObj);
            return Results.Created($"/customer/{responseObj.Id}", obj);
        }
        catch (Exception e)
        {
            return Results.BadRequest(e);
        }        
    }

    static async Task<IResult> Update(Guid id, CustomerRequests.Update obj, IBaseRepository<Customer> repository, IMapper mapper)
    {
        try
        {
            var oldObj = await repository.GetById(id);

            if (oldObj is null) return TypedResults.NotFound();

            oldObj.Name = obj.Name;
            oldObj.Email = obj.Email;
            oldObj.BirthDate = obj.BirthDate;

            await repository.Update(oldObj);

            return Results.Accepted($"/customer/{oldObj.Id}", oldObj);
        }
        catch (Exception e)
        {
            return Results.BadRequest(e);
        }
    }

    static async Task<IResult> Delete(Guid id, IBaseRepository<Customer> repository)
    {
        try
        {
            if (await repository.GetById(id) is Customer obj)
            {
                await repository.Delete(obj);
                return TypedResults.Ok();
            }

            return TypedResults.NotFound();
        }
        catch (Exception e)
        {
            return Results.BadRequest(e);
        }
    }
}
