using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace timsoft.entities
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRole { get; set; }
        public string? RoleName { get; set; }
        [NotMapped]
        [JsonIgnore]
        public ICollection<User>? Users { get; set; }

    }
}
