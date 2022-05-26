using System;
using DataBase;
using UoW;
using Repository;

namespace BLL.Tests
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly DeliveryContext context;
        private readonly IGenericRepository<Delivery> deliveryRepository;
        private readonly IGenericRepository<Food> foodRepository;
        private readonly IGenericRepository<Set> setRepository;
        public IUnitOfWork unitOfWork;

        public TestCommandBase()
        {
            context = ContextFactory.Create();
            deliveryRepository = new ContextRepository<Delivery>(context);
            foodRepository = new ContextRepository<Food>(context);
            setRepository = new ContextRepository<Set>(context);
            unitOfWork = new UnitOfWork(context, deliveryRepository, foodRepository, setRepository);
        }

        public void Dispose() => ContextFactory.Destroy(context);
    }
}
