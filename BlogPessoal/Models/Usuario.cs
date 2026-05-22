using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlogPessoal.Models;

[Table("tb_usuario")]
public class Usuario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    [StringLength(150)]
    [Column("nome")]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(255)]
    [Column("email")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(255)]
    [Column("senha")]
    public string Senha {  get; set; } = string.Empty;

    [JsonIgnore]
    public ICollection<Postagem>? Postagens { get; set; }

    public Usuario() 
    {}

    public Usuario(string nome, string email, string senha)
    {
        this.Nome = nome;
        this.Email = email;
        this.Senha= senha;
    }
}
