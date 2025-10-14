using Pegaucho.Shared.Responses;

namespace PegauchoBackend.UnitsOfWork.Interfaces;

public interface IGenericRepository<T> where T : class
{
    //Polimorfismo por interface
    Task<ActionResponse<T>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<T>>> GetAsync();

    Task<ActionResponse<T>> AddAsync(T entity);

    Task<ActionResponse<T>> DeleteAsync(int id);

    Task<ActionResponse<T>> UpdateAsync(T entity);
}

