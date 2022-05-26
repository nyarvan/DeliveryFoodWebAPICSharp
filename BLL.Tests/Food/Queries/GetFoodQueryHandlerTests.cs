using CommandsAndQueries;
using System;
using System.Threading;
using System.Threading.Tasks;
using UoW;
using AutoMapper;
using ViewModels;
using Xunit;
using Shouldly;

namespace BLL.Tests
{
    [Collection("QueryCollection")]
    public class GetFoodQueryHandlerTests
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetFoodQueryHandlerTests(QueryTestFixture fixture) =>
            (unitOfWork, mapper) = (fixture.unitOfWork, fixture.mapper);

        [Fact]
        public async Task GetClubPassQueryHandler_Success()
        {
            // Arrange
            var handler = new FoodQueryHandler(unitOfWork, mapper);

            // Act
            var result = await handler.Handle(new FoodQuery
            { Id = Guid.Parse("1E897888-B44E-4282-8290-2FD26FE78B15") }, CancellationToken.None);


            // Assert
            result.ShouldBeOfType<FoodModel>();
            result.Name.ShouldBe("Борщ");
            result.Price.ShouldBe(50);
        }

        [Fact]
        public async Task GetPassClubQueryHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new FoodQueryHandler(unitOfWork, mapper);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new FoodQuery
            { Id = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}
