using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System;

namespace BLL.Tests
{
    public class RemoveFoodCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task RemoveFoodCommandHandler_Success()
        {
            // Arrange 
            var handler = new RemoveFoodCommandHandler(unitOfWork);

            // Act
            await handler.Handle(new RemoveFoodCommand
            {
                Id = ContextFactory.FoodIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(await context.Foods.SingleOrDefaultAsync(food =>
            food.Id == ContextFactory.FoodIdForDelete));
        }

        [Fact]
        public async Task RemoveClubPassCommandHandler_FailedOnWrongId()
        {
            // Arrange
            var handler = new RemoveFoodCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new RemoveFoodCommand
            { Id = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}
