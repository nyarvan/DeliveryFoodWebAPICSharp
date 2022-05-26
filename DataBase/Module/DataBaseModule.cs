using Autofac;

namespace DataBase
{
    public class DataBaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DeliveryContext>().
                WithParameter("options", DbContextOptionsFactory.Get()).AsSelf().SingleInstance();
        }
    }
}
