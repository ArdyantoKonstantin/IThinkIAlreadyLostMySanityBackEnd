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
    public class GetTheaterDetailHandler : IRequestHandler<GetTheaterDetailRequest, GetTheaterDetailResponse>
    {
        ExamDbContext _db;

        public GetTheaterDetailHandler(ExamDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<GetTheaterDetailResponse> Handle(GetTheaterDetailRequest request, CancellationToken cancellationToken)
        {
            if (_db.Theaters == null)
            {
                return new GetTheaterDetailResponse()
                {
                    CinemaName = "NotFound",
                    TypeId = "NotFound"
                };
            }
            var theater = await _db.Theaters
                .AsNoTracking()
                .Where(Q => Q.Id == request.Id)
                .Select(Q => new GetTheaterDetailResponse
                {
                    CinemaId = Q.CinemaId,
                    CinemaName = Q.Cinema.Name,
                    TypeId = Q.TheaterTypeId,
                    TypeName = Q.TheaterType.Type
                }).FirstOrDefaultAsync();

            if (theater == null)
            {
                return new GetTheaterDetailResponse()
                {
                    CinemaName = "NotFoundTheaterNull",
                    TypeId = "NotFoundTheaterNull"
                };
            }
            return theater;
        }
    }
}
