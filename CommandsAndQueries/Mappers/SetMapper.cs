using AutoMapper;
using DataBase;
using ViewModels;

namespace CommandsAndQueries
{
    public class SetMapper : Profile
    {
        public SetMapper() { CreateMap<Set, SetModel>().ReverseMap(); }
    }
}
