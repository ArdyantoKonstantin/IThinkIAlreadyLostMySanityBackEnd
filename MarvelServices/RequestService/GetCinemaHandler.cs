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
    public class GetCinemaHandler : IRequestHandler<GetCinemaRequest, GetCinemaResponse>
    {
        ExamDbContext _db;
        public GetCinemaHandler(ExamDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<GetCinemaResponse> Handle(GetCinemaRequest request, CancellationToken cancellationToken)
        {
            var query = _db.Cinemas;
            var cinema = await query.
                Skip(request.Limit * request.Offset).
                Take(request.Limit).
                Select(s => new CinemaDetails()
                {
                    Id = s.Id,
                    Name = s.Name,
                    BlobId = s.BlobId,
                    FileUrl = s.Blob.FileName
                }).ToListAsync();
            var totalData = await query.CountAsync();
            return new GetCinemaResponse
            {
                Cinemas = cinema,
                TotalData = totalData
            };
        }
    }
}
