using System;
using System.Threading.Tasks;
using Xunit;
using CommandsAndQueries;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace BLL.Tests
{
    public class AddDeliveryCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task AddDeliveryCommandHandler_Success() 
        {
            //Arange
            var handler = new AddDeliveryCommandHandler(unitOfWork);
            var Name = "Name";
            var Phone = "Phone";
            var DeliveryTime = new DateTime();

            //Act
            var deliveryId = await handler.Handle(
                new AddDeliveryCommand
                {
                    Name = Name,
                    Phone = Phone,
                    DeliveryTime = DeliveryTime
                }, CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Deliveries.SingleOrDefaultAsync(delivery =>
                delivery.Id == deliveryId && delivery.Name == Name && delivery.Phone == Phone && delivery.DeliveryTime == DeliveryTime));
        }
    }
}
