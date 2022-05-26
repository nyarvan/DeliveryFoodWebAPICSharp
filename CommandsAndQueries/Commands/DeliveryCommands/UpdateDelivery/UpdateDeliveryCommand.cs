using System;
using MediatR;

namespace CommandsAndQueries
{
    public class UpdateDeliveryCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime DeliveryTime { get; set; }
    }
}
