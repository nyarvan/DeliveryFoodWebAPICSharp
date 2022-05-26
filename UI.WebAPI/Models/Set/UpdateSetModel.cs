using System;

namespace UI.WebAPI
{
    public class UpdateSetModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid? DeliveryId { get; set; }
    }
}
