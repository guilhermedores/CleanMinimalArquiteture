using Microsoft.EntityFrameworkCore;

public class BaseRepository<T> : IBaseRepository<T> where T : Entity
{
    public readonly BaseDbContext Context;

    public BaseRepository(BaseDbContext context)
    {
        Context = context;
    }

    public async Task<T?> GetById(Guid id)
    {
        var obj = await Context.Set<T>().FindAsync(id);
        return obj;
    }

    public async Task<List<T>> GetAll()
    {
        var obj = await Context.Set<T>().ToListAsync();
        return obj;
    }

    public async Task<T> Create(T obj)
    {
        Context.Set<T>().Add(obj);
        await Context.SaveChangesAsync();

        return obj;
    }

    public async Task<T> Update(T obj)
    {
        Context.Set<T>().Update(obj);
        await Context.SaveChangesAsync();

        return obj;
    }

    public async Task Delete(T obj)
    {
        Context.Set<T>().Remove(obj);
        await Context.SaveChangesAsync();
    }
}