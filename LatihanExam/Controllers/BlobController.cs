using MarvelContract.RequestModel;
using MarvelContract.ResponseModel;
using MarvelEntity.Entity;
using MarvelServices.Interface;
using MarvelServices.Options;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LatihanExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobController : ControllerBase
    {
        private readonly IStorageProvider _storageProvider;
        private readonly ExamDbContext _dbContext;
        private readonly string _bucketName;
        private readonly IMediator _mediator;
        public BlobController(IStorageProvider storageProvider, ExamDbContext dbContext, IOptions<MinIoOptions> minioOptions, IMediator mediator)
        {
            _storageProvider = storageProvider;
            _dbContext = dbContext;
            _bucketName = minioOptions.Value.BucketName;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetPresignedUrl(string fileName)
        {
            var urlFile = await _storageProvider.GetPresignedUrl(fileName);
            return Ok(urlFile);
        }

        [HttpGet("redirect")]
        public async Task<ActionResult<string>> GetPresignedUrlRedirect(string fileName)
        {
            var urlFile = await _storageProvider.GetPresignedUrl(fileName);
            return Redirect(urlFile);
        }

        [HttpGet("presigned-put-object")]
        public async Task<ActionResult<string>> GetPutPresignedUrl(string fileName)
        {
            var urlFile = await _storageProvider.GetPutPresignedUrl(fileName);
            return Ok(urlFile);
        }

        [HttpPost("blob-information")]
        public async Task<ActionResult<BlobInformationResponse>> PostBlobInformation([FromBody] BlobInformationRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }
    }
}
