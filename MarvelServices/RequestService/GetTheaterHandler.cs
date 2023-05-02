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
    public class GetTheaterHandler : IRequestHandler<GetTheaterRequest, GetTheaterResponse>
    {
        ExamDbContext _db;
        public GetTheaterHandler(ExamDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<GetTheaterResponse> Handle(GetTheaterRequest request, CancellationToken cancellationToken)
        {
            var query = _db.Theaters.OrderBy(Q => Q.Id).AsQueryable();
            if (request.NextId != 0)
            {
                query = query.Where(Q => Q.Id > request.NextId);
            }
            else if (request.PrevId != 0)
            {
                query = query.OrderByDescending(Q => Q.Id).Where(Q => Q.Id < request.PrevId);

            }
            var result = await query.Take(request.Limit).Select(Q => new TheaterDetails
            {
                Id = Q.Id,
                Name = Q.Name,
                TheaterType = Q.TheaterType.Type,
                CinemaName = Q.Cinema.Name
            }).ToListAsync();
            result = result.OrderBy(Q => Q.Id).ToList();
            var nextCursorId = result.LastOrDefault()?.Id;
            var prevCursorId = result.FirstOrDefault()?.Id;

            return new GetTheaterResponse()
            {
                Theaters = result,
                PrevCursor = $"api/User/cursor-pagination?prevId={prevCursorId}&limit=3",
                NextCursor = $"api/User/cursor-pagination?nextId={nextCursorId}&limit=3"
            };
        }
    }
}
