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
    public class DeliveryController : BaseController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public DeliveryController(IMediator mediator, IMapper mapper) 
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<DeliveryModel>>> GetAll()
        {
            var query = new GetDeliveryListQuery { };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryModel>> Get(Guid id)
        {
            var query = new GetDeliveryQuery { Id = id };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add([FromBody] AddDeliveryModel addDeliveryModel)
        {
            var command = mapper.Map<AddDeliveryCommand>(addDeliveryModel);
            var deliveryId = await mediator.Send(command);
            return Created($"{deliveryId}", deliveryId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDeliveryModel updateDeliveryModel)
        {
            var command = mapper.Map<UpdateDeliveryCommand>(updateDeliveryModel);
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var command = new RemoveDeliveryCommand { Id = id };
            await mediator.Send(command);
            return NoContent();
        }
    }
}
