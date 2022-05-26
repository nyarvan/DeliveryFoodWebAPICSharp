using System;
using System.Collections.Generic;

namespace DataBase
{
    public class Set
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Food> Foods { get; set; }

        public Guid? DeliveryId { get; set; }
        public Delivery Delivery { get; set; }
    }
}
