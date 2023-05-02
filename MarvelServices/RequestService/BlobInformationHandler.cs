using MarvelContract.RequestModel;
using MarvelContract.ResponseModel;
using MarvelEntity.Entity;
using MarvelServices.Interface;
using MarvelServices.Options;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelServices.RequestService
{
    public class BlobInformationHandler : IRequestHandler<BlobInformationRequest, BlobInformationResponse>
    {
        private readonly IStorageProvider _storageProvider;
        private readonly ExamDbContext _dbContext;
        private readonly string _bucketName;

        public BlobInformationHandler(IStorageProvider storageProvider, ExamDbContext dbContext, IOptions<MinIoOptions> minioOptions)
        {
            _storageProvider = storageProvider;
            _dbContext = dbContext;
            _bucketName = minioOptions.Value.BucketName;
        }
        public async Task<BlobInformationResponse> Handle(BlobInformationRequest request, CancellationToken cancellationToken)
        {
            var blob = new Blob
            {
                BlobId = request.Id,
                FileName = request.FileName,
                CreatedAt = DateTimeOffset.UtcNow,
                FilePath = $"{_bucketName}/{request.Id}",
                MIME = request.Mime,
            };
            _dbContext.Blobs.Add(blob);
            try
            {
                await _dbContext.SaveChangesAsync();
                return new BlobInformationResponse()
                {
                    Success = "success"
                };
            }
            catch(Exception ex)
            {
                return new BlobInformationResponse()
                {
                    Success = ex.Message
                };
            }
            
        }
    }
}
