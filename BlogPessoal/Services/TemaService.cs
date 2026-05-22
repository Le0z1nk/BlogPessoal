using BlogPessoal.Models;
using BlogPessoal.Repositories;

namespace BlogPessoal.Services;

public class TemaService : ITemaService
{
    private readonly ITemaRepository Repository;

    public TemaService(ITemaRepository repository) 
    {
        Repository = repository; 
    }

    public async Task<Tema?> Create(Tema tema)
    {
        return await Repository.Create(tema);
    }

    public async Task<Tema?> Update(Tema tema)
    {
        return await Repository.Update(tema);
    }

    public async Task<bool> Delete(long id)
    {
        return await Repository.Delete(id);
    }

    public async Task<IEnumerable<Tema>> GetAll() => await Repository.GetAll();
}
