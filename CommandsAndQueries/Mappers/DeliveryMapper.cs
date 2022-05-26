using AutoMapper;
using DataBase;
using ViewModels;

namespace CommandsAndQueries
{
    public class DeliveryMapper : Profile
    {
        public DeliveryMapper() { CreateMap<Delivery, DeliveryModel>().ReverseMap(); }
    }
}
