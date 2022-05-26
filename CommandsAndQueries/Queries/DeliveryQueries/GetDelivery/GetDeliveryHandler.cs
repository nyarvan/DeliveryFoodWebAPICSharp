using MediatR;
using ViewModels;
using UoW;
using DataBase;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsAndQueries
{
    public class GetDeliveryQueryHandler : IRequestHandler<GetDeliveryQuery, DeliveryModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetDeliveryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<DeliveryModel> Handle(GetDeliveryQuery request, CancellationToken cancellationToken)
        {
            var delivery = await unitOfWork.Deliveries.GetByIdAsync(request.Id, cancellationToken);
            if (delivery == null || delivery.Id != request.Id)
                throw new NotFoundException(nameof(Delivery), request.Id);
            return mapper.Map<DeliveryModel>(delivery);
        }
    }
}
