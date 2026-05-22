using BlogPessoal.Models;

namespace BlogPessoal.Repositories;

public interface ITemaRepository
{
    Task<Tema> Create(Tema tema);
    Task<Tema?> Update(Tema tema);
    Task<bool> Delete(long id);
    Task<IEnumerable<Tema>> GetAll();
}
