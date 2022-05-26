using CommandsAndQueries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BLL.Tests
{
    public class RemoveDeliveryCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task RemoveDeliveryCommandHandler_Success()
        {
            // Arrange 
            var handler = new RemoveDeliveryCommandHandler(unitOfWork);

            // Act
            await handler.Handle(new RemoveDeliveryCommand
            {
                Id = ContextFactory.DeliveryIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(await context.Deliveries.SingleOrDefaultAsync(delivery =>
            delivery.Id == ContextFactory.DeliveryIdForDelete));
        }

        [Fact]
        public async Task RemoveDeliveryCommandHandler_FailedOnWrongId()
        {
            // Arrange
            var handler = new RemoveDeliveryCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new RemoveDeliveryCommand
            { Id = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}
