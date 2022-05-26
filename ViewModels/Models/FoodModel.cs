using System;

namespace ViewModels
{
    public class FoodModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Guid? SetId { get; set; }
        public SetModel Set { get; set; }

        public Guid? DeliveryId { get; set; }
        public DeliveryModel Delivery { get; set; }

        public override string ToString()
        {
            return $"Страва {Name} - ціна: {Price}";
        }
    }
}
