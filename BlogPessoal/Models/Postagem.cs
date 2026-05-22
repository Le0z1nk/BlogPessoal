using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlogPessoal.Models;

[Table("tb_postagem")]
public class Postagem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    [StringLength(100)]
    [Column("titulo")]
    public string Titulo { get; set; } = string.Empty;

    [Required]
    [Column("conteudo")]
    public string Conteudo {  get; set; } = string.Empty;

    public DateTime Data { get; set; } = DateTime.UtcNow;

    [Required]
    public long UsuarioId { get; set; }
    [ForeignKey("UsuarioId")]
    [JsonIgnore]
    public Usuario? Usuario { get; set; }
    
    [Required]
    public long TemaId { get; set; }
    [ForeignKey("TemaId")]
    [JsonIgnore]
    public Tema? Tema { get; set; }

    public Postagem() { }

    public Postagem(string titulo, string conteudo, DateTime data, Usuario usuario, Tema tema)
    {
        this.Titulo = titulo;
        this.Conteudo = conteudo;
        this.Data = data;
        this.Usuario = usuario;
        this.Tema = tema;
    }
}
