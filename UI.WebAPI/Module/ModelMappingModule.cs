using Autofac;
using AutoMapper;
using CommandsAndQueries;


namespace UI.WebAPI
{
    public class ModelMappingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DeliveryMapper>();
                cfg.AddProfile<FoodMapper>();
                cfg.AddProfile<SetMapper>();
                cfg.AddProfile<DeliveryModelMapper>();
                cfg.AddProfile<FoodModelMapper>();
                cfg.AddProfile<SetModelMapper>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
        }
    }
}
