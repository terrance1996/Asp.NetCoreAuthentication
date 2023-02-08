using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace timsoft.entities
{
    public class UserEpreuve
    {
       
        public int IdEpreuve { get; set; }
        public int IdUser { get; set; }
        public int Score { get; set; }
        public string? Resultat { get; set; }
        public DateTime date_lim { get; set; }
        public User User { get; set; }
        public Epreuve Epreuve { get; set; }

    }
}
