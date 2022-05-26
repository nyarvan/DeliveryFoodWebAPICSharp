using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UoW;
using DataBase;

namespace CommandsAndQueries
{
    public class AddDeliveryCommandHandler : IRequestHandler<AddDeliveryCommand, Guid>
    {
        private readonly IUnitOfWork unitOfWork;
        public AddDeliveryCommandHandler(IUnitOfWork unitOfWork) =>
           this.unitOfWork = unitOfWork;

        public async Task<Guid> Handle(AddDeliveryCommand request, CancellationToken cancellationToken)
        {
            var delivery = new Delivery
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Phone = request.Phone,
                DeliveryTime = request.DeliveryTime
            };
            await unitOfWork.Deliveries.AddAsync(delivery, cancellationToken);
            await unitOfWork.SaveAsync(cancellationToken);
            return delivery.Id;
        }
    }
}
