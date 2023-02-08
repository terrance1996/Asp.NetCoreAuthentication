using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace timsoft.entities
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdQuest { get; set; }
        public string Intitule { get; set; }
        public int Durée { get; set; }
        public string Catégorie { get; set; }
        public int Point { get; set; }
        public int NbRep { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<Reponse> Reponse { get; set; }

        [NotMapped]
        [JsonIgnore]
        public List<Epreuve> Epreuve { get; set; }


    }
}
