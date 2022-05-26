using System;
using MediatR;

namespace CommandsAndQueries
{
    public class RemoveDeliveryCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
