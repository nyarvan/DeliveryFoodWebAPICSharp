using System.Collections.Generic;
using MediatR;
using ViewModels;

namespace CommandsAndQueries
{
    public class GetDeliveryListQuery : IRequest<List<DeliveryModel>>
    {
    }
}
