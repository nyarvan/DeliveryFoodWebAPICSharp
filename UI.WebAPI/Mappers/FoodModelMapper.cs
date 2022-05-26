using CommandsAndQueries;
using AutoMapper;

namespace UI.WebAPI
{
    public class FoodModelMapper : Profile
    {
        public FoodModelMapper()
        {
            CreateMap<AddFoodModel, AddFoodCommand>();
            CreateMap<UpdateFoodModel, UpdateFoodCommand>();
        }
    }
}
