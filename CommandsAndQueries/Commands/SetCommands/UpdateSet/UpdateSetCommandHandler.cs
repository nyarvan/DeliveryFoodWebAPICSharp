using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UoW;
using DataBase;

namespace CommandsAndQueries
{
    public class UpdateSetCommandHandler : IRequestHandler<UpdateSetCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public UpdateSetCommandHandler(IUnitOfWork unitOfWork) =>
            this.unitOfWork = unitOfWork;

        public async Task<Unit> Handle(UpdateSetCommand request, CancellationToken cancellationToken)
        {
            Delivery delivery = null;
            if (request.DeliveryId != null)
                delivery = unitOfWork.Deliveries.Get((Guid)request.DeliveryId);

            var set = await unitOfWork.Sets.GetByIdAsync(request.Id, cancellationToken);
            if (set == null)
                throw new NotFoundException(nameof(Food), request.Id);
            set.Id = request.Id;
            set.Name = request.Name;
            set.DeliveryId = request.DeliveryId;
            await unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
