using CommandsAndQueries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BLL.Tests
{
    public class UpdateDeliveryCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateDeliveryCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateDeliveryCommandHandler(unitOfWork);
            var updatedName = "New name";


            // Act
            await handler.Handle(new UpdateDeliveryCommand
            {
                Id = ContextFactory.DeliveryIdForUpdate,
                Name = updatedName
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await context.Deliveries.SingleOrDefaultAsync(delivery =>
            delivery.Id == ContextFactory.DeliveryIdForUpdate && delivery.Name == updatedName));
        }

        [Fact]
        public async Task UpdateDeliveryCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateDeliveryCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new UpdateDeliveryCommand
            {
                Id = Guid.NewGuid(),
            }, CancellationToken.None));
        }

    }
}
