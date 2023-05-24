public interface IBaseRepository<T> where T : Entity
{
    Task<T?> GetById(Guid id);
    Task<List<T>> GetAll();
    Task<T> Create(T obj);
    Task<T> Update(T obj);
    Task Delete(T obj);
}