using MarvelContract.RequestModel;
using MarvelContract.ResponseModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LatihanExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheaterTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TheaterTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("theater-type-list")]
        public async Task<ActionResult<GetTheaterTypeResponse>> GetCinemaNormal([FromQuery] GetTheaterTypeRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }
    }
}
