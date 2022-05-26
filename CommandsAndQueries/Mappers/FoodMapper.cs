using AutoMapper;
using DataBase;
using ViewModels;

namespace CommandsAndQueries
{
    public class FoodMapper : Profile
    {
        public FoodMapper() { CreateMap<Food, FoodModel>().ReverseMap(); }
    }
}
