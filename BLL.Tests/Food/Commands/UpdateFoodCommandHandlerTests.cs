using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System;

namespace BLL.Tests
{
    public class UpdateFoodCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateClubPassCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateFoodCommandHandler(unitOfWork);
            var updatedName = "NewName";


            // Act
            await handler.Handle(new UpdateFoodCommand
            {
                Id = ContextFactory.FoodIdForUpdate,
                Name = updatedName
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await context.Foods.SingleOrDefaultAsync(food =>
            food.Id == ContextFactory.FoodIdForUpdate && food.Name == updatedName));
        }

        [Fact]
        public async Task UpdateClubPassCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateFoodCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new UpdateFoodCommand
            {
                Id = Guid.NewGuid(),

            }, CancellationToken.None));
        }
    }
}
