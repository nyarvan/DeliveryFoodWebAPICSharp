using DataBase;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UoW;

namespace CommandsAndQueries
{
    public class RemoveSetCommandHandler : IRequestHandler<RemoveSetCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public RemoveSetCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoveSetCommand request, CancellationToken cancellationToken)
        {
            var set = await unitOfWork.Sets.GetByIdAsync(request.Id, cancellationToken);
            if (set == null)
                throw new NotFoundException(nameof(Set), request.Id);
            unitOfWork.Sets.Remove(set.Id);
            await unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
