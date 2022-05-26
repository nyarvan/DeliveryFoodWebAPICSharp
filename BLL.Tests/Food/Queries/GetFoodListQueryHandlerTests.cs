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
    public class GetFoodListQueryHandlerTests
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetFoodListQueryHandlerTests(QueryTestFixture fixture) =>
            (unitOfWork, mapper) = (fixture.unitOfWork, fixture.mapper);

        [Fact]
        public async Task GetClubPassListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetFoodQueryHandler(unitOfWork, mapper);

            // Act
            var result = await handler.Handle(new GetFoodQuery() { },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<List<FoodModel>>();
            result.Count.ShouldBe(4);
        }
    }
}
