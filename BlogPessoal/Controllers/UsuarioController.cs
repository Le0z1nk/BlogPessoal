using BlogPessoal.DTOs;
using BlogPessoal.Models;
using BlogPessoal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogPessoal.Controllers;

[ApiController]
[Route("api/usuarios")]
[Authorize]
[Produces("application/json")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService Service;

    public UsuarioController(IUsuarioService service)
    {
        this.Service = service;
    }
    
    [HttpPost("cadastrar")]
    [AllowAnonymous]
    public async Task<ActionResult<Usuario>> CreateAsync([FromBody] Usuario usuario)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var usuarioNovo = await Service.Create(usuario);
        if (usuarioNovo == null)
            return Conflict(new { mensagem = "Usuario ja cadastrado" });

        return StatusCode(StatusCodes.Status201Created, usuarioNovo);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Usuario>> UpdateAsync(long id, [FromBody] Usuario usuario)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var usuarioAtualizado = await Service.Update(usuario);
        if (usuarioAtualizado == null)
            return NotFound(new { mensagem = "Usuario não encontrado" });

        return Ok(usuarioAtualizado);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var usuarioDeletado = await Service.Delete(id);
        if (!usuarioDeletado)
            return NotFound(new { mensagem = "Usuario não foi encontrado" });

        return NoContent();
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<UsuarioLogin>> LoginAsync([FromBody] UsuarioLogin usuarioLogin)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var login = await Service.Login(usuarioLogin);
        if (login == null)
            return Unauthorized(new { mensagem = "email ou senha invalidos" });

        return Ok(login);
    }
}
