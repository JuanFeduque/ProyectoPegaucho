using Pegaucho.Shared.DTOs;

namespace Pegaucho.Frontend.Client.Repositories;

public class OrdenProduccionRepository : IOrdenProduccionRepository
{
    private readonly IRepository _repository;
    private const string _url = "api/ordenproduccion";

    public OrdenProduccionRepository(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<HttpResponseWrapper<List<OrdenProduccionDTO>>> GetAsync()
    {
        return await _repository.GetAsync<List<OrdenProduccionDTO>>(_url);
    }

    public async Task<HttpResponseWrapper<OrdenProduccionDTO>> GetAsync(int id)
    {
        return await _repository.GetAsync<OrdenProduccionDTO>($"{_url}/{id}");
    }

    public async Task<HttpResponseWrapper<OrdenProduccionDTO>> PostAsync(OrdenProduccionDTO ordenProduccion)
    {
        return await _repository.PostAsync<OrdenProduccionDTO, OrdenProduccionDTO>(_url, ordenProduccion);
    }

    public async Task<HttpResponseWrapper<object>> PutAsync(int id, OrdenProduccionDTO ordenProduccion)
    {
        return await _repository.PutAsync($"{_url}/{id}", ordenProduccion);
    }

    public async Task<HttpResponseWrapper<object>> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync($"{_url}/{id}");
    }
}