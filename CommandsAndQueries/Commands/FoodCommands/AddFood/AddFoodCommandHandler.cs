using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UoW;
using DataBase;

namespace CommandsAndQueries
{

    public class AddFoodCommandHandler : IRequestHandler<AddFoodCommand, Guid>
    {
        private readonly IUnitOfWork unitOfWork;
        public AddFoodCommandHandler(IUnitOfWork unitOfWork) =>
           this.unitOfWork = unitOfWork;

        public async Task<Guid> Handle(AddFoodCommand request, CancellationToken cancellationToken)
        {
            
            var food = new Food
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
            };
         
            await unitOfWork.Foods.AddAsync(food, cancellationToken);
            await unitOfWork.SaveAsync(cancellationToken);
            return food.Id;
        }
    }
}
