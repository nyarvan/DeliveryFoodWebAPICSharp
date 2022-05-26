using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class DbContextOptionsFactory
    {
        public static DbContextOptions<DeliveryContext> Get()
        {
            var builder = new DbContextOptionsBuilder<DeliveryContext>();
            builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DeliveryFoodlab6-7DB");
            return builder.Options;
        }
    }
}
