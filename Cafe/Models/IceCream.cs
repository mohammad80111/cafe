using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe.Models
{
    public class IceCream
    {
        public int id { get; set; }

        public string name { get; set; }

        public decimal Price { get; set; }


   
        public int SizeId { get; set; }
        public Size size { get; set; }
    }
}
