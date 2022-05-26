using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UoW;
using DataBase;

namespace CommandsAndQueries
{
    public class UpdateFoodCommandHandler : IRequestHandler<UpdateFoodCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public UpdateFoodCommandHandler(IUnitOfWork unitOfWork) =>
            this.unitOfWork = unitOfWork;

        public async Task<Unit> Handle(UpdateFoodCommand request, CancellationToken cancellationToken)
        {
            var food = await unitOfWork.Foods.GetByIdAsync(request.Id, cancellationToken);
            if (food == null)
                throw new NotFoundException(nameof(Food), request.Id);

            Delivery delivery = null;
            if(request.DeliveryId != null)
            {
                delivery = unitOfWork.Deliveries.Get((Guid)request.DeliveryId);
                food.DeliveryId = delivery.Id;
                food.Delivery = delivery;
            }

            Set set = null;
            if (request.SetId != null)
            {
                set = unitOfWork.Sets.Get((Guid)request.SetId);
                food.SetId = set.Id;
                food.Set = set;
            }
            
            food.Id = request.Id;
            food.Name = request.Name;
            food.Price = request.Price;
            
            await unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
