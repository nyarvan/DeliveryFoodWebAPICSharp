using System;

namespace UI.WebAPI
{
    public class UpdateFoodModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Guid? DeliveryId { get; set; }
        public Guid? SetId { get; set; }
    }
}
