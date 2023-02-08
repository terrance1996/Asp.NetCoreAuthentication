using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace timsoft.entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUser { get; set; }
        public string? Username { get; set; }
        public string? Nom { get; set; }
        public string? Prénom { get; set; }
        public string Password { get; set; }    
        [NotMapped]
        [JsonIgnore]
        public List<Invitation> Invitations { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<Réclamation> Réclamation { get; set; }

        [NotMapped]
        [JsonIgnore]
        public List<Role> Roles { get; set; }

        [NotMapped]
        [JsonIgnore]
        public List<UserEpreuve> UserEpreuves { get; set; }
    }
}
