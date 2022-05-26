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
    public class GetDeliveryQueryHandlerTests
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetDeliveryQueryHandlerTests(QueryTestFixture fixture) =>
            (unitOfWork, mapper) = (fixture.unitOfWork, fixture.mapper);

        [Fact]
        public async Task GetDeliveryQueryHandler_Success()
        {
            // Arrange
            var handler = new GetDeliveryQueryHandler(unitOfWork, mapper);

            // Act
            var result = await handler.Handle(new GetDeliveryQuery
            { Id = Guid.Parse("36F0407C-7202-46BF-9A1B-1D67507AB9BB") }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<DeliveryModel>();
            result.Name.ShouldBe("Ivan");
            result.Phone.ShouldBe("+380667899504");
            //result.DeliveryTime.ShouldBe(DateTime.Parse("2022 - 05 - 25T21: 15:15.7476297 + 03:00"));
        }

        [Fact]
        public async Task GetDeliveryQueryHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new GetDeliveryQueryHandler(unitOfWork, mapper);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new GetDeliveryQuery
            { Id = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}
