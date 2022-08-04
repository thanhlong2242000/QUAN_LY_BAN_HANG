using System;

namespace BanHang.Domain.Models
{
    public class Order
    {
        public int Order_ID { get; set; }
        public DateTime Date_Order { get; set; }
        public float Discount { get; set; }
        public float Total_Cost { get; set; }
        public int User_ID { get; set; }
        public User User { get; set; }
    }
}
