using CommandsAndQueries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoMapper;
using UoW;
using ViewModels;
using Shouldly;

namespace BLL.Tests
{
    [Collection("QueryCollection")]
    public class GetDeliveryListQueryHandlerTests
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetDeliveryListQueryHandlerTests(QueryTestFixture fixture) =>
            (unitOfWork, mapper) = (fixture.unitOfWork, fixture.mapper);

        [Fact]
        public async Task GetDeliveryListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetDeliveryListQueryHandler(unitOfWork, mapper);

            // Act
            var result = await handler.Handle(new GetDeliveryListQuery() { },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<List<DeliveryModel>>();
            result.Count.ShouldBe(4);
        }
    }
}
