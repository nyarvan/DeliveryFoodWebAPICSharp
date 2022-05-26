using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommandsAndQueries;
using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace UI.WebAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class SetController : BaseController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public SetController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<SetModel>>> GetAll()
        {
            var query = new GetSetListQuery { };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SetModel>> Get(Guid id)
        {
            var query = new GetSetQuery { Id = id };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add([FromBody] AddSetModel addSetModel)
        {
            var command = mapper.Map<AddSetCommand>(addSetModel);
            var setId = await mediator.Send(command);
            return Created($"{setId}", setId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSetModel updateSetModel)
        {
            var command = mapper.Map<UpdateSetCommand>(updateSetModel);
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var command = new RemoveSetCommand { Id = id };
            await mediator.Send(command);
            return NoContent();
        }
    }
}
