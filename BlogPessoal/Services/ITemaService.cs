using BlogPessoal.Models;

namespace BlogPessoal.Services
{
    public interface ITemaService
    {
        Task<Tema?> Create(Tema tema);
        Task<Tema?> Update(Tema tema);
        Task<bool> Delete(long id);
        Task<IEnumerable<Tema>> GetAll();

    }
}
