using System;
using DataBase;
using Microsoft.EntityFrameworkCore;

namespace BLL.Tests
{
    public static class ContextFactory
    {
        public static Guid DeliveryIdForUpdate = Guid.NewGuid();
        public static Guid DeliveryIdForDelete = Guid.NewGuid();

        public static Guid FoodIdForUpdate = Guid.NewGuid();
        public static Guid FoodIdForDelete = Guid.NewGuid();

        public static Guid SetIdForUpdate = Guid.NewGuid();
        public static Guid SetIdForDelete = Guid.NewGuid();

        public static DeliveryContext Create() 
        {
            var options = new DbContextOptionsBuilder<DeliveryContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new DeliveryContext(options);
            context.Database.EnsureCreated();
            context.Deliveries.AddRange(
                new Delivery 
                {
                    Id = Guid.Parse("36F0407C-7202-46BF-9A1B-1D67507AB9BB"),
                    Name = "Ivan",
                    Phone = "+380667899504",
                    DeliveryTime = DateTime.Now
                },
                new Delivery
                {
                    Id = Guid.Parse("AD442107-E5F8-4623-A309-D82970836F15"),
                    Name = "Oleg",
                    Phone = "+380661234567",
                    DeliveryTime = DateTime.Now
                },
                new Delivery
                {
                    Id = DeliveryIdForUpdate,
                    Name = "Alex",
                    Phone = "+3809765432112",
                    DeliveryTime = DateTime.Now
                },
                new Delivery
                {
                    Id = DeliveryIdForDelete,
                    Name = "Name4",
                    Phone = "+3809765432115",
                    DeliveryTime = DateTime.Now
                });
            context.Foods.AddRange(
                new Food
                {
                    Id = Guid.Parse("1E897888-B44E-4282-8290-2FD26FE78B15"),
                    Name = "Борщ",
                    Price = 50
                },
                new Food
                {
                    Id = Guid.Parse("CDF6BD57-3512-4206-95B3-819AC8630DB7"),
                    Name = "Карбонаро",
                    Price = 150
                },
                new Food
                {
                    Id = FoodIdForUpdate,
                    Name = "Бургер",
                    Price = 75
                },
                new Food
                {
                    Id = FoodIdForDelete,
                    Name = "Піцца",
                    Price = 200
                });
            context.Sets.AddRange(
                new Set
                {
                    Id = Guid.Parse("04981315-E9E1-4639-8AFB-AC7319B417DF"),
                    Name = "Український обід"
                 },
                new Set
                {
                    Id = Guid.Parse("4C1F38F2-AF12-40EC-A8D4-FB439285ABF9"),
                    Name = "Американський обід"
                },
                new Set
                {
                    Id = SetIdForUpdate,
                    Name = "Італійський обід"
                },
                new Set
                {
                    Id = SetIdForDelete,
                    Name = "Японський обід"
                });
            context.SaveChanges();
            return context;
        }

        public static void Destroy(DeliveryContext context) 
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
