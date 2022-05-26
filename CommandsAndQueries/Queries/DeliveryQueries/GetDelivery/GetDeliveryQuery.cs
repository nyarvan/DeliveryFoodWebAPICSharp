using System;
using MediatR;
using ViewModels;

namespace CommandsAndQueries
{
    public class GetDeliveryQuery : IRequest<DeliveryModel>
    {
        public Guid Id { get; set; }

    }
}
