namespace Core_MVCApp.Services
{
    public interface IService<TEntity,in TPk> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(TPk id);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TPk id, TEntity entity);
        Task<TEntity> Delete(TPk id);
    }
}
