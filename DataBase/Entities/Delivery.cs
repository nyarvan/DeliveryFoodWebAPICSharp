using System;
using System.Collections.Generic;

namespace DataBase
{
    public class Delivery
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime DeliveryTime { get; set; }
        public List<Food> Foods { get; set; }
        public List<Set> Sets { get; set; }
    }
}
