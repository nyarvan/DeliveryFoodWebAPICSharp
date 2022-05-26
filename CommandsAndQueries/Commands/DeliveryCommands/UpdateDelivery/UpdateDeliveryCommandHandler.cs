using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UoW;
using DataBase;

namespace CommandsAndQueries
{
    public class UpdateDeliveryCommandHandler : IRequestHandler<UpdateDeliveryCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public UpdateDeliveryCommandHandler(IUnitOfWork unitOfWork) =>
            this.unitOfWork = unitOfWork;

        public async Task<Unit> Handle(UpdateDeliveryCommand request, CancellationToken cancellationToken)
        {
            var delivery = await unitOfWork.Deliveries.GetByIdAsync(request.Id, cancellationToken);
            if (delivery == null)
                throw new NotFoundException(nameof(Delivery), request.Id);
            delivery.Id = request.Id;
            delivery.Name = request.Name;
            delivery.Phone = request.Phone;
            delivery.DeliveryTime = request.DeliveryTime;
            await unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
