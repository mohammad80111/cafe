namespace Cafe.Models
{
    public class chocolate
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }


        public int SizeId { get; set; }
        public Size size { get; set; }
    }
}
