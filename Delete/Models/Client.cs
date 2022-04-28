using System.ComponentModel.DataAnnotations;

namespace Delete.Models
{
    public class Client
    {
        [Key]
        public long id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
