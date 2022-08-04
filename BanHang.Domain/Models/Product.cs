namespace BanHang.Domain.Models
{
    public class Product
    {
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public int Product_Number { get; set; }
        public string Product_Detail { get; set; }
        public float Price { get; set; }
        public int Availability { get; set; }
    }
}
