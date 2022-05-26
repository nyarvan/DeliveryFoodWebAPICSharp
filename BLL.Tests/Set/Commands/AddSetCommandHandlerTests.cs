using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace BLL.Tests
{
    public class AddSetCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task AddUserCommandHandler_Success()
        {
            //Arange
            var handler = new AddSetCommandHandler(unitOfWork);
            var Name = "Name";

            //Act
            var setId = await handler.Handle(
                new AddSetCommand
                {
                    Name = Name

                }, CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Sets.SingleOrDefaultAsync(set =>
                set.Id == setId && set.Name == Name));
        }
    }
}
