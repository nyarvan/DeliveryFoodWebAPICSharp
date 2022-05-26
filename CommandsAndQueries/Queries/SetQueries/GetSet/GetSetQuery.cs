using System;
using MediatR;
using ViewModels;

namespace CommandsAndQueries
{
    public class GetSetQuery : IRequest<SetModel>
    {
        public Guid Id { get; set; }

    }
}
