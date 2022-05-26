using System;
using System.Collections.Generic;

namespace ViewModels
{
    public class DeliveryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime DeliveryTime { get; set; }
        public List<FoodModel> Foods { get; set; }
        public List<SetModel> Sets { get; set; }

        public override string ToString()
        {
            string foods = "";
            foreach (FoodModel food in Foods)
                foods += food.Name + ", ";

            foreach (SetModel set in Sets)
                foods += set.Name + ", ";

            return $"Замовлення для {Name} ({Phone})" +
                $"\nЧас: {DeliveryTime}" +
                $"\nСписок: {foods}";
        }
    }
}
