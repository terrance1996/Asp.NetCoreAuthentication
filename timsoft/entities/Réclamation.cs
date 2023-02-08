using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace timsoft.entities
{
    public class Réclamation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdReclam { get; set; }
        public string Objet { get; set; }
        public string Description { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<User> Users { get; set; }

    }
}
