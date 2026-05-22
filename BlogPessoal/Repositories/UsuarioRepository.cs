using BlogPessoal.Data;
using BlogPessoal.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPessoal.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext Context;

    public UsuarioRepository(AppDbContext context)
    {
        Context = context;
    }

    public async Task<Usuario?> GetByEmail(string email) => await Context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

    public async Task<Usuario> Create(Usuario usuario)
    {
        Context.Usuarios.Add(usuario);
        await Context.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario> Update(Usuario usuario)
    {
        Context.Usuarios.Update(usuario);
        await Context.SaveChangesAsync();
        return usuario;
    }

    public async Task<bool> Delete(long id)
    {
        var usuario = await Context.Usuarios.FindAsync(id);
        if (usuario == null)
            return false;

        Context.Usuarios.Remove(usuario);
        await Context.SaveChangesAsync();
        return true;
    }

}
