using BlogPessoal.Data;
using BlogPessoal.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPessoal.Repositories;

public class TemaRepository : ITemaRepository
{
    private readonly AppDbContext Context;

    public TemaRepository(AppDbContext context)
    {
        Context = context;
    }

    public async Task<Tema> Create(Tema tema)
    {
        Context.Temas.Add(tema);
        await Context.SaveChangesAsync();
        return tema;
    }

    public async Task<Tema?> Update(Tema tema)
    {
        var temaExiste = await Context.Temas.FindAsync(tema.Id);
        temaExiste.Descricao = tema.Descricao;
        await Context.SaveChangesAsync();
        return temaExiste;
    }

    public async Task<bool> Delete(long id)
    {
        var tema = await Context.Temas.FindAsync(id);
        if (tema == null)
            return false;

        Context.Temas.Remove(tema);
        await Context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Tema>> GetAll() => await Context.Temas.Include(t => t.Postagens).ToListAsync();
}
