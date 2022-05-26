using Autofac;
using DataBase;

namespace Repository
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContextRepository<Delivery>>().As<IGenericRepository<Delivery>>();
            builder.RegisterType<ContextRepository<Food>>().As<IGenericRepository<Food>>();
            builder.RegisterType<ContextRepository<Set>>().As<IGenericRepository<Set>>();
        }
    }
}
