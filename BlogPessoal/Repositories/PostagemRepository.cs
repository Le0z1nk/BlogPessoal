using BlogPessoal.Data;
using BlogPessoal.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPessoal.Repositories;

public class PostagemRepository : IPostagemRepository
{
    private readonly AppDbContext Context;

    public PostagemRepository(AppDbContext context)
    {
        Context = context;
    }

    private IQueryable<Postagem> QueryRelacionamentos() => Context.Postagens.Include(p => p.Tema).Include(p => p.Usuario).AsQueryable();

    public async Task<Postagem> Create(Postagem postagem)
    {
        Context.Postagens.Add(postagem);
        await Context.SaveChangesAsync();
        return postagem;
    }

    public async Task<Postagem> Update(Postagem postagem)
    {
        Context.Postagens.Update(postagem);
        await Context.SaveChangesAsync();
        return postagem;
    }

    public async Task<bool> Delete(long id)
    {
        var postagem = await Context.Postagens.FindAsync(id);
        if (postagem == null)
            return false;

        Context.Postagens.Remove(postagem);
        await Context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Postagem>> GetAll() => await QueryRelacionamentos().ToListAsync();

    public async Task<IEnumerable<Postagem>> GetByFilter(long? autorId, long? temaId)
    {
        var query = QueryRelacionamentos();
        if (autorId.HasValue)
        {
            query = query.Where(p => p.UsuarioId == autorId.Value);
        }
        if (temaId.HasValue)
        {
            query = query.Where(p => p.TemaId == temaId.Value);
        }

        return await query.ToListAsync();
    }
}
