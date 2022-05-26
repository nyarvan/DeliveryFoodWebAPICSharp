using DataBase;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UoW;

namespace CommandsAndQueries
{
    public class RemoveFoodCommandHandler : IRequestHandler<RemoveFoodCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public RemoveFoodCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoveFoodCommand request, CancellationToken cancellationToken)
        {
            var food = await unitOfWork.Foods.GetByIdAsync(request.Id, cancellationToken);
            if (food == null)
                throw new NotFoundException(nameof(Food), request.Id);
            unitOfWork.Foods.Remove(food.Id);
            await unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
