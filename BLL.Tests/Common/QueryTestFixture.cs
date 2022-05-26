using System;
using System.Collections.Generic;
using DataBase;
using UoW;
using Repository;
using AutoMapper;
using CommandsAndQueries;
using UI.WebAPI;
using Xunit;


namespace BLL.Tests
{
    public class QueryTestFixture : IDisposable
    {
        private readonly DeliveryContext context;
        private readonly IGenericRepository<Delivery> deliveryRepository;
        private readonly IGenericRepository<Food> foodRepository;
        private readonly IGenericRepository<Set> setRepository;
        public IUnitOfWork unitOfWork;
        public IMapper mapper;

        public QueryTestFixture()
        {
            context = ContextFactory.Create();
            deliveryRepository = new ContextRepository<Delivery>(context);
            foodRepository = new ContextRepository<Food>(context);
            setRepository = new ContextRepository<Set>(context);

            unitOfWork = new UnitOfWork(context, deliveryRepository, foodRepository, setRepository);
            var configurationProvider = new MapperConfiguration(cfg =>
            cfg.AddProfiles(new List<Profile>()
            {

                new DeliveryMapper(),
                new FoodMapper(),
                new SetMapper(),

                new DeliveryModelMapper(),
                new FoodModelMapper(),
                new SetModelMapper(),
            }));
            mapper = configurationProvider.CreateMapper();
        }

        public void Dispose() => ContextFactory.Destroy(context);
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
