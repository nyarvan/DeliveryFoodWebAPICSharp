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
    public class FoodController : BaseController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public FoodController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<FoodModel>>> GetAll()
        {
            var query = new GetFoodQuery { };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FoodModel>> Get(Guid id)
        {
            var query = new FoodQuery { Id = id };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add([FromBody] AddFoodModel addFoodModel)
        {
            var command = mapper.Map<AddFoodCommand>(addFoodModel);
            var food = await mediator.Send(command);
            return Created($"{food}", food);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFoodModel updateFoodModel)
        {
            var command = mapper.Map<UpdateFoodCommand>(updateFoodModel);
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var command = new RemoveFoodCommand { Id = id };
            await mediator.Send(command);
            return NoContent();
        }
    }
}
