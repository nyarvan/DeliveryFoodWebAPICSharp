using System;

namespace DataBase
{
    public class Food
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Guid? SetId { get; set; }

        public Set Set { get; set; }

        public Guid? DeliveryId { get; set; }
        public Delivery Delivery { get; set; }
    }
}
