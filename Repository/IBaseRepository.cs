namespace IALClient.Repository;

public interface IBaseRepository<T>
{
    
    Task<List<T>> GetAll();


    Task<T?> GetById(long id);


    Task<T> Save(T entity);


    Task Update();

    Task Delete(T entity);

    Task<bool> Exists(long id);
    
}