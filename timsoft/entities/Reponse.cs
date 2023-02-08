using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace timsoft.entities
{
    public class Reponse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdReponse { get; set; }
        public string? Flag { get; set; }
        public List<Question> Question {get; set;} 
    }
}
