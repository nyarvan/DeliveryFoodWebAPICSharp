using System;
using MediatR;

namespace CommandsAndQueries
{
    public class RemoveSetCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
