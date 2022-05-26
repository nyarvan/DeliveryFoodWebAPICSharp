using CommandsAndQueries;
using AutoMapper;

namespace UI.WebAPI
{
    public class SetModelMapper : Profile
    {
        public SetModelMapper()
        {
            CreateMap<AddSetModel, AddSetCommand>();
            CreateMap<UpdateSetModel, UpdateSetCommand>();
        }
    }
}
