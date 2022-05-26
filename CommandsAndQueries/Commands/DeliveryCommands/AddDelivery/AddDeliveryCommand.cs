using System;
using MediatR;

namespace CommandsAndQueries
{
    public class AddDeliveryCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime DeliveryTime { get; set; }
    }
}
