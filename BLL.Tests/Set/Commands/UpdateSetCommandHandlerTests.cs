using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System;

namespace BLL.Tests
{
    public class UpdateSetCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateUserCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateSetCommandHandler(unitOfWork);
            var updatedName = "NewName";


            // Act
            await handler.Handle(new UpdateSetCommand
            {
                Id = ContextFactory.SetIdForUpdate,
                Name = updatedName
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await context.Sets.SingleOrDefaultAsync(set =>
            set.Id == ContextFactory.SetIdForUpdate && set.Name == updatedName));
        }

        [Fact]
        public async Task UpdateUserCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateSetCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new UpdateSetCommand
            {
                Id = Guid.NewGuid(),
            }, CancellationToken.None));
        }
    }
}
