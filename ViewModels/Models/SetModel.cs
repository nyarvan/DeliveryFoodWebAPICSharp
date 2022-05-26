using System;
using System.Collections.Generic;


namespace ViewModels
{
    public class SetModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<FoodModel> Foods { get; set; }

        public Guid? DeliveryId { get; set; }
        public DeliveryModel Delivery { get; set; }

        public override string ToString()
        {
            string foods = "";
            foreach (FoodModel food in Foods)
                foods += food.Name + ", ";

            return $"Комплекс {Name}" +
                 $"\nСписок страв: {foods}";
        }
    }
}
