using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace timsoft.entities
{
    public class Type_Epreuve
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdType { get; set; }
        public string? Type { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<Epreuve> Epreuve { get; set; }

    }
}
