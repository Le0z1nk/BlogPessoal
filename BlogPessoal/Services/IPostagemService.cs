using BlogPessoal.Models;

namespace BlogPessoal.Services;

public interface IPostagemService
{
    Task<Postagem?> Create(Postagem postagem);
    Task<Postagem?> Update(Postagem postagem);
    Task<bool> Delete(long id);
    Task<IEnumerable<Postagem>> GetAll();
    Task<IEnumerable<Postagem>> GetByFilter(long? autorId, long? temaId);

}
