using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace BLL.Tests
{
    public class AddFoodCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task AddClubPassCommandHandler_Success()
        {
            //Arange
            var handler = new AddFoodCommandHandler(unitOfWork);
            var Name = "Name";
            var Price = 128;

            //Act
            var foodId = await handler.Handle(
                new AddFoodCommand
                {
                    Name = Name,
                    Price = Price,
                }, CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Foods.SingleOrDefaultAsync(food =>
                food.Id == foodId && food.Name == Name && food.Price == Price));
        }
    }
}
