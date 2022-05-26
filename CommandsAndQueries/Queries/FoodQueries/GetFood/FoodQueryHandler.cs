using MediatR;
using ViewModels;
using UoW;
using DataBase;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsAndQueries
{   
    public class FoodQueryHandler : IRequestHandler<FoodQuery, FoodModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public FoodQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<FoodModel> Handle(FoodQuery request, CancellationToken cancellationToken)
        {
            var food = await unitOfWork.Foods.GetByIdAsync(request.Id, cancellationToken);
            if (food == null || food.Id != request.Id)
                throw new NotFoundException(nameof(Food), request.Id);
            return mapper.Map<FoodModel>(food);
        }
    }
}
