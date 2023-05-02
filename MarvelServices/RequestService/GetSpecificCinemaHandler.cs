using MarvelContract.RequestModel;
using MarvelContract.ResponseModel;
using MarvelEntity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelServices.RequestService
{
    public class GetSpecificCinemaHandler : IRequestHandler<GetSpecificCinemaRequest, GetSpecificCinemaResponse>
    {
        ExamDbContext _db;

        public GetSpecificCinemaHandler(ExamDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<GetSpecificCinemaResponse> Handle(GetSpecificCinemaRequest request, CancellationToken cancellationToken)
        {
            if(request.Id == null)
            {
                return new GetSpecificCinemaResponse()
                {
                    Address = "NotFound",
                    BlobName = "NotFound"
                };
            }
            if (_db.Cinemas == null)
            {
                return new GetSpecificCinemaResponse()
                {
                    Address = "NotFound",
                    BlobName = "NotFound"
                };
            }
            if (_db.Blobs == null)
            {
                return new GetSpecificCinemaResponse()
                {
                    Address = "NotFound",
                    BlobName = "NotFound"
                };
            }
            var cinema = await _db.Cinemas
                .AsNoTracking()
                .Where(Q => Q.Id == request.Id)
                .Select(Q => new GetSpecificCinemaResponse
                {
                    Address = Q.Address,
                    BlobName = Q.Blob.FileName
                }).FirstOrDefaultAsync();

            if (cinema == null)
            {
                return new GetSpecificCinemaResponse()
                {
                    Address = "NotFound",
                    BlobName = "NotFound"
                };
            }
            return cinema;
        }
    }
}
