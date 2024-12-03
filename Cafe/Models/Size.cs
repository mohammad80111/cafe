using System.ComponentModel.DataAnnotations;

namespace Cafe.Models
{
    public class Size
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
