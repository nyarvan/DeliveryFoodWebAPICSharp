using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System;

namespace BLL.Tests
{
    public class RemoveSetCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task RemoveUserCommandHandler_Success()
        {
            // Arrange 
            var handler = new RemoveSetCommandHandler(unitOfWork);

            // Act
            await handler.Handle(new RemoveSetCommand
            {
                Id = ContextFactory.SetIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(await context.Sets.SingleOrDefaultAsync(set =>
            set.Id == ContextFactory.SetIdForDelete));
        }

        [Fact]
        public async Task RemoveUserCommandHandler_FailedOnWrongId()
        {
            // Arrange
            var handler = new RemoveSetCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new RemoveSetCommand
            { Id = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}
