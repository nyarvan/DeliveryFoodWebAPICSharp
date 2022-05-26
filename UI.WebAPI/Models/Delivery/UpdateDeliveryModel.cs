using System;

namespace UI.WebAPI
{
    public class UpdateDeliveryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime DeliveryTime { get; set; }
    }
}
