using System;
using System.Threading;
using System.Threading.Tasks;
using UoW;
using AutoMapper;
using ViewModels;
using Xunit;
using Shouldly;
using CommandsAndQueries;

namespace BLL.Tests
{
    [Collection("QueryCollection")]
    public class GetSetQueryHandlerTests
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetSetQueryHandlerTests(QueryTestFixture fixture) =>
            (unitOfWork, mapper) = (fixture.unitOfWork, fixture.mapper);

        [Fact]
        public async Task GetUserQueryHandler_Success()
        {
            // Arrange
            var handler = new GetSetQueryHandler(unitOfWork, mapper);

            // Act
            var result = await handler.Handle(new GetSetQuery
            { Id = Guid.Parse("04981315-E9E1-4639-8AFB-AC7319B417DF") }, CancellationToken.None);


            // Assert
            result.ShouldBeOfType<SetModel>();
            result.Name.ShouldBe("Український обід");

        }

        [Fact]
        public async Task GetUserQueryHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new GetSetQueryHandler(unitOfWork, mapper);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new GetSetQuery
            { Id = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}
