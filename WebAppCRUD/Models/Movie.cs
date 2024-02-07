using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        public int id { get; set; }
        public string? MName { get; set; }
        public string? StarCast { get; set; }

        public string? Director { get; set;}
        public DateTime ReleaseDate { get; set; }

    }
}
