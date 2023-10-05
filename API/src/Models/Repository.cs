using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Repository
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int Stars { get; set; }
        public int Watchers { get; set; }
        public string Language { get; set; }
    }
}