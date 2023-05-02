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
    public class GetCinemaNormalHandler : IRequestHandler<GetCinemaNormalRequest, List<GetCinemaNormalResponse>>
    {
        ExamDbContext _db;
        public GetCinemaNormalHandler(ExamDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<List<GetCinemaNormalResponse>> Handle(GetCinemaNormalRequest request, CancellationToken cancellationToken)
        {
            var cinemaList = await _db.Cinemas.Select(s => new GetCinemaNormalResponse()
            {
                CinemaId = s.Id,
                CinemaName = s.Name
            }).ToListAsync();

            return cinemaList;
        }
    }
}
