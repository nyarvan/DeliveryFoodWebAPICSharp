using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UoW;
using DataBase;

namespace CommandsAndQueries
{
    public class AddSetCommandHandler : IRequestHandler<AddSetCommand, Guid>
    {
        private readonly IUnitOfWork unitOfWork;
        public AddSetCommandHandler(IUnitOfWork unitOfWork) =>
           this.unitOfWork = unitOfWork;

        public async Task<Guid> Handle(AddSetCommand request, CancellationToken cancellationToken)
        {
        
            var set = new Set
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            await unitOfWork.Sets.AddAsync(set, cancellationToken);
            await unitOfWork.SaveAsync(cancellationToken);
            return set.Id;
        }
    }
}
