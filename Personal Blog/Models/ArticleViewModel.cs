using System.ComponentModel.DataAnnotations;

namespace Personal_Blog.Models
{
    public class ArticleViewModel
    {
        public int ID { get; set; }

        public string heading { get; set; }

        public DateTime date { get; set; }

        [StringLength(5000, MinimumLength =50)]
        public string content { get; set; }
    }
}
