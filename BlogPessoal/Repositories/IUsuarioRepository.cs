using BlogPessoal.Models;

namespace BlogPessoal.Repositories;

public interface IUsuarioRepository
{
    Task<Usuario> Create(Usuario usuario);
    Task<Usuario> Update(Usuario usuario);
    Task<bool> Delete(long id);
    Task<Usuario?> GetByEmail(string email);
}
