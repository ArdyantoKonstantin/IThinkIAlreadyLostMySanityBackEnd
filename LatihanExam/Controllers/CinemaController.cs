using MarvelContract.RequestModel;
using MarvelContract.ResponseModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LatihanExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CinemaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("cinema-list-normal")]
        public async Task<ActionResult<GetCinemaNormalResponse>> GetCinemaNormal([FromQuery] GetCinemaNormalRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpGet("cinema-list")]
        public async Task<ActionResult<GetCinemaResponse>> GetCinema([FromQuery] GetCinemaRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpGet("cinema-detail/")]
        public async Task<ActionResult<GetSpecificCinemaResponse>> GetCinemaDetail([FromQuery]GetSpecificCinemaRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpPost("UpdateCinema")]
        public async Task<ActionResult<UpdateCinemaResponse>> PutCinema([FromQuery] UpdateCinemaRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpPost("/register-cinema")]
        public async Task<ActionResult<RegisterCinemaResponse>> PostCinema([FromBody] RegisterCinemaRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }
    }
}
