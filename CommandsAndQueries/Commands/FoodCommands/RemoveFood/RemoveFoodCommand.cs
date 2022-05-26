using System;
using MediatR;

namespace CommandsAndQueries
{
    public class RemoveFoodCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
