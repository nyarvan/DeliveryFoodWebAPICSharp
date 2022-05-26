using CommandsAndQueries;
using AutoMapper;

namespace UI.WebAPI
{
    public class DeliveryModelMapper : Profile
    {
        public DeliveryModelMapper() 
        {
            CreateMap<AddDeliveryModel, AddDeliveryCommand>();
            CreateMap<UpdateDeliveryModel, UpdateDeliveryCommand>();
        }
    }
}
