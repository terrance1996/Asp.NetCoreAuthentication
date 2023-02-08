using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace timsoft.entities
{
    public class Epreuve
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int 
            IdEpreuve { get; set; }
        public string? NomEpreuve { get; set; }
        public int Duree { get; set; }
        public int SommePoints { get; set; }
        public string? Complexité { get; set; }
        public Type_Epreuve Type_Epreuves  { get; set; }

        [NotMapped]
        [JsonIgnore]
        public List<UserEpreuve> UserEpreuves { get; set; }

        [NotMapped]
        [JsonIgnore]
        public List<Question> Question { get; set; }

    }
}
