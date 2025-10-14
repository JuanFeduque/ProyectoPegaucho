using Pegaucho.Shared.DTOs;

namespace Pegaucho.Frontend.Client.Repositories;

public interface IOrdenProduccionRepository
{
    Task<HttpResponseWrapper<List<OrdenProduccionDTO>>> GetAsync();
    Task<HttpResponseWrapper<OrdenProduccionDTO>> GetAsync(int id);
    Task<HttpResponseWrapper<OrdenProduccionDTO>> PostAsync(OrdenProduccionDTO ordenProduccion);
    Task<HttpResponseWrapper<object>> PutAsync(int id, OrdenProduccionDTO ordenProduccion);
    Task<HttpResponseWrapper<object>> DeleteAsync(int id);
}
