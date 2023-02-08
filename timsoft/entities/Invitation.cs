using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace timsoft.entities
{
    public class Invitation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdInv { get; set; }
        public DateTime date_inv { get; set; }
        public string? description { get; set; }

        public User User { get; set; }
    }
}
