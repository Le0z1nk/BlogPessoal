using BlogPessoal.Models;
using BlogPessoal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogPessoal.Controllers;

[ApiController]
[Route("api/postagens")]
[Authorize]
[Produces("application/json")]
public class PostagemController : ControllerBase
{
    private readonly IPostagemService Service;

    public PostagemController(IPostagemService service)
    {
        Service = service;
    }

    [HttpPost]
    public async Task<ActionResult<Postagem>> CreateAsync([FromBody] Postagem postagem)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var usuarioIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioIdClaim == null || !long.TryParse(usuarioIdClaim, out var usuarioId))
        {
            return Unauthorized(new { mensagem = "Usuario não identificado" });
        }

        postagem.UsuarioId = usuarioId;
        var novaPostagem = await Service.Create(postagem);
        if (novaPostagem == null)
            return NotFound(new { mensagem = "postagem não existe" });

        return StatusCode(StatusCodes.Status201Created, novaPostagem);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Postagem>> UpdateAsync(long id, [FromBody] Postagem postagem)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        postagem.Id = id;

        var usuarioIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioIdClaim == null || !long.TryParse(usuarioIdClaim, out var usuarioId))
        {
            return Unauthorized(new { mensagem = "Usuário não identificado" });
        }
        postagem.UsuarioId = usuarioId;

        var postagemAtualizada = await Service.Update(postagem);
        if (postagemAtualizada == null)
            return NotFound(new { mensagem = "postagem não encontrado" });

        return Ok(postagemAtualizada);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var postagemDeletada = await Service.Delete(id);
        if (!postagemDeletada)
            return NotFound(new { mensagem = "Postagem não encontrada" });

        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Postagem>>> GetAllAsync() => Ok(await Service.GetAll());

    [HttpGet("filtro")]
    public async Task<ActionResult<IEnumerable<Postagem>>> GetByFilterAsync([FromQuery] long? autor, [FromQuery] long? tema)
    {
        return Ok(await Service.GetByFilter(autor, tema));
    }

}
