using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using UoW;
using ViewModels;

namespace CommandsAndQueries
{
    public class GetSetListQueryHandler : IRequestHandler<GetSetListQuery, List<SetModel>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetSetListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<SetModel>> Handle(GetSetListQuery request, CancellationToken cancellationToken)
        {
            var sets = await unitOfWork.Sets.GetAllAsync(cancellationToken);
            return mapper.Map<List<SetModel>>(sets);
        }
    }
}
