using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlogPessoal.Models;

[Table("tb_tema")]
public class Tema
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    [StringLength(255)]
    [Column("descricao")]
    public string Descricao { get; set; } = string.Empty;

    [JsonIgnore]
    public ICollection<Postagem>? Postagens { get; set; }

    public Tema()
    {}

    public Tema(string descricao)
    {
        this.Descricao = descricao;
    }
}
