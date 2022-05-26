using System;
using MediatR;

namespace CommandsAndQueries
{
    public class AddSetCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
