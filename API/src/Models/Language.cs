
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Language
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }
        public string Name { get; set; }
        public List<Repository> Repositories { get; set; }
    }
}