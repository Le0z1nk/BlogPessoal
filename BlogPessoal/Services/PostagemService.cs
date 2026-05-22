using BlogPessoal.Models;
using BlogPessoal.Repositories;

namespace BlogPessoal.Services;

public class PostagemService : IPostagemService
{
    private readonly IPostagemRepository Repository;

    public PostagemService(IPostagemRepository repository)
    {
        Repository = repository;
    }

    public async Task<Postagem?> Create(Postagem postagem)
    {
        return await Repository.Create(postagem);
    }

    public async Task<Postagem?> Update(Postagem postagem)
    {
        
        return await Repository.Update(postagem);
    }

    public async Task<bool> Delete(long id) => await Repository.Delete(id);

    public async Task<IEnumerable<Postagem>> GetAll()
    {
        return await Repository.GetAll();
    }

    public async Task<IEnumerable<Postagem>> GetByFilter(long? autorId, long? temaId)
    {
        return await Repository.GetByFilter(autorId, temaId);
    }
}
