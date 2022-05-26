using System;
using MediatR;
using ViewModels;

namespace CommandsAndQueries
{
    public class FoodQuery : IRequest<FoodModel>
    {
        public Guid Id { get; set; }
    }
}
