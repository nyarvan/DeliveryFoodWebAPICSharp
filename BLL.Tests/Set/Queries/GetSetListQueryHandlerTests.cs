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
    public class GetSetListQueryHandlerTests
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetSetListQueryHandlerTests(QueryTestFixture fixture) =>
            (unitOfWork, mapper) = (fixture.unitOfWork, fixture.mapper);

        [Fact]
        public async Task GetUserListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetSetListQueryHandler(unitOfWork, mapper);

            // Act
            var result = await handler.Handle(new GetSetListQuery() { },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<List<SetModel>>();
            result.Count.ShouldBe(4);
        }
    }
}
