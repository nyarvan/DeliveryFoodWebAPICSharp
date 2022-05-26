using System;
using MediatR;

namespace CommandsAndQueries
{
    public class UpdateSetCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DeliveryId { get; set; }
    }
}
