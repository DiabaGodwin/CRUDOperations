namespace CRUDOperation.Application.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<int> Add(FormattableString sqlQuery);
        Task<IEnumerable<TEntity>> GetAllAsync(string query);
        Task<int> Update(FormattableString sqlQuery);
        Task<int> Delete(FormattableString sqlQuery);
        Task<TEntity> GetBrandById(FormattableString sqlQuery);
        Task<int> Insert(FormattableString sqlQuery);
    }
}
