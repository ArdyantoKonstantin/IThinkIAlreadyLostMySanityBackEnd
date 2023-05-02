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
    public class GetTheaterTypeHandler : IRequestHandler<GetTheaterTypeRequest, List<GetTheaterTypeResponse>>
    {
        ExamDbContext _db;
        public GetTheaterTypeHandler(ExamDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<List<GetTheaterTypeResponse>> Handle(GetTheaterTypeRequest request, CancellationToken cancellationToken)
        {
            var theaterTypeList = await _db.TheaterTypes.Select(s => new GetTheaterTypeResponse()
            {
                TypeId = s.Id,
                TypeName = s.Type
            }).ToListAsync();

            return theaterTypeList;
        }
    }
}
