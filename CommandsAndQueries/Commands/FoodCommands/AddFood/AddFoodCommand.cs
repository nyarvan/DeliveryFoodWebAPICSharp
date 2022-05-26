using System;
using MediatR;

namespace CommandsAndQueries
{
    public class AddFoodCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
