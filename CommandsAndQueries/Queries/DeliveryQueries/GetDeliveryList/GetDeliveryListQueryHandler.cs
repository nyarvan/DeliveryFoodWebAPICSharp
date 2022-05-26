using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ViewModels;
using AutoMapper;
using UoW;

namespace CommandsAndQueries
{
    public class GetDeliveryListQueryHandler : IRequestHandler<GetDeliveryListQuery, List<DeliveryModel>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetDeliveryListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<DeliveryModel>> Handle(GetDeliveryListQuery request, CancellationToken cancellationToken)
        {
            var deliveries = await unitOfWork.Deliveries.GetAllAsync(cancellationToken);
            return mapper.Map<List<DeliveryModel>>(deliveries);
        }
    }
}
