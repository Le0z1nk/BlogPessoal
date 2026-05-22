using BlogPessoal.DTOs;
using BlogPessoal.Models;
using BlogPessoal.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogPessoal.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository Repository;
    private readonly IConfiguration Config;

    public UsuarioService(IUsuarioRepository repository, IConfiguration config)
    {
        Repository = repository;
        Config = config;
    }

    public async Task<Usuario?> Create(Usuario usuario)
    {
        usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
        return await Repository.Create(usuario);
    }

    public async Task<Usuario?> Update(Usuario usuario)
    {
        usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
        return await Repository.Update(usuario);
    }

    public async Task<bool> Delete(long id) => await Repository.Delete(id);

    public async Task<UsuarioLogin?> Login(UsuarioLogin usuarioLogin)
    {
        var buscaUsuario = await Repository.GetByEmail(usuarioLogin.UsuarioEmail);
        if (buscaUsuario == null || !BCrypt.Net.BCrypt.Verify(usuarioLogin.Senha, buscaUsuario.Senha))
        {
            return null;
        }

        usuarioLogin.Token = GerarToken(buscaUsuario);
        usuarioLogin.Senha = string.Empty;

        return usuarioLogin;
    } 

    private string GerarToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(Config["Jwt:Key"] ?? string.Empty);
        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
                [
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email)
                ]),
            Expires = DateTime.UtcNow.AddHours(int.Parse(Config["Jwt:ExpireHours"] ?? "3")),
            Issuer = Config["Jwt:Issuer"],
            Audience = Config["Jwt:Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        };

        var token = tokenHandler.CreateToken(descriptor);
        return tokenHandler.WriteToken(token);
    }
}
