using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personal_Blog.Models
{
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Required]
        public string heading { get; set; }

        [Required]
        public DateTime date { get; set; }

        [Required]
        [StringLength(5000, MinimumLength =50)]
        public string content { get; set; }

    }
}
