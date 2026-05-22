using BlogPessoal.Repositories;
using BlogPessoal.Services;

namespace BlogPessoal.Config;

public static class ConfigDependency
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<IPostagemRepository, PostagemRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<ITemaRepository, TemaRepository>();

        services.AddScoped<IPostagemService, PostagemService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<ITemaService, TemaService>();

        return services;
    }
}
