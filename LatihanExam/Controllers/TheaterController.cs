using MarvelContract.RequestModel;
using MarvelContract.ResponseModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LatihanExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheaterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TheaterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-theater-list")]
        public async Task<ActionResult<GetTheaterResponse>> GetTheater([FromQuery] GetTheaterRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpPost("register-theater")]
        public async Task<ActionResult<RegisterTheaterResponse>> PostTheater([FromBody] RegisterTheaterRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpGet("theater-detail/")]
        public async Task<ActionResult<GetTheaterDetailResponse>> GetCinemaDetail([FromQuery] GetTheaterDetailRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpPost("update-theater/")]
        public async Task<ActionResult<UpdateTheaterResponse>> UpdateTheater([FromQuery] UpdateTheaterRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }
    }
}
