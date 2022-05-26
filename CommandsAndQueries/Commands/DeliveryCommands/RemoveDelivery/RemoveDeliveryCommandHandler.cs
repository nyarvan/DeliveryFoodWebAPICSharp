using DataBase;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UoW;

namespace CommandsAndQueries
{
    public class RemoveDeliveryCommandHandler : IRequestHandler<RemoveDeliveryCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public RemoveDeliveryCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoveDeliveryCommand request, CancellationToken cancellationToken)
        {
            var delivery = await unitOfWork.Deliveries.GetByIdAsync(request.Id, cancellationToken);
            if (delivery == null)
                throw new NotFoundException(nameof(Delivery), request.Id);
            unitOfWork.Deliveries.Remove(delivery.Id);
            await unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
