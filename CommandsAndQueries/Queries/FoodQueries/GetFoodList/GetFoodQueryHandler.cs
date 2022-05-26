using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ViewModels;
using AutoMapper;
using UoW;

namespace CommandsAndQueries
{
    public class GetFoodQueryHandler : IRequestHandler<GetFoodQuery, List<FoodModel>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetFoodQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }  

        public async Task<List<FoodModel>> Handle(GetFoodQuery request, CancellationToken cancellationToken)
        {
            var foods = await unitOfWork.Foods.GetAllAsync(cancellationToken);
            return mapper.Map<List<FoodModel>>(foods);
        }
    }
}
