using MediatR;
using ViewModels;
using UoW;
using DataBase;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsAndQueries
{
    public class GetSetQueryHandler : IRequestHandler<GetSetQuery, SetModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetSetQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<SetModel> Handle(GetSetQuery request, CancellationToken cancellationToken)
        {
            var set = await unitOfWork.Sets.GetByIdAsync(request.Id, cancellationToken);
            if (set == null || set.Id != request.Id)
                throw new NotFoundException(nameof(Food), request.Id);
            return mapper.Map<SetModel>(set);
        }
    }
}
