using BlogPessoal.DTOs;
using BlogPessoal.Models;

namespace BlogPessoal.Services;

public interface IUsuarioService
{
    Task<Usuario?> Create(Usuario usuario);
    Task<Usuario?> Update(Usuario usuario);
    Task<bool> Delete(long id);
    Task<UsuarioLogin?> Login(UsuarioLogin usuarioLogin);
}
