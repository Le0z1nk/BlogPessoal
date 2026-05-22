using BlogPessoal.Models;
using BlogPessoal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogPessoal.Controllers;

[ApiController]
[Route("api/temas")]
[Authorize]
[Produces("application/json")]
public class TemaController : ControllerBase
{
    private readonly ITemaService Service;

    public TemaController(ITemaService service)
    {
        Service = service;
    }

    [HttpPost]
    public async Task<ActionResult<Tema>> CreateAsync([FromBody] Tema tema)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var novoTema = await Service.Create(tema);
        return StatusCode(StatusCodes.Status201Created, tema);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Tema>> UpdateAsync(long id, [FromBody] Tema tema)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        tema.Id = id;
        var temaAtualizado = await Service.Update(tema);
        if (temaAtualizado == null)
            return NotFound(new { mensagem = "tema não encontrado" });

        return Ok(temaAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var temaDeletado = await Service.Delete(id);
        if (!temaDeletado)
            return NotFound(new { mensagem = "tema não foi encontrado" });

        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tema>>> GetAllAsync() => Ok(await Service.GetAll());
}
