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
    public class UpdateTheaterHandler : IRequestHandler<UpdateTheaterRequest, UpdateTheaterResponse>
    {
        ExamDbContext _db;

        public UpdateTheaterHandler(ExamDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<UpdateTheaterResponse> Handle(UpdateTheaterRequest request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                return new UpdateTheaterResponse()
                {
                    Success = "Not found"
                };
            }
            var update = await _db.Theaters.Where(Q => Q.Id == request.Id).FirstOrDefaultAsync();
            if (update == null)
            {
                return new UpdateTheaterResponse()
                {
                    Success = "Not found"
                };
            }

            update.TheaterTypeId = request.TypeId;
            update.CinemaId = request.CinemaId;
            try
            {
                await _db.SaveChangesAsync();
                return new UpdateTheaterResponse()
                {
                    Success = "Success"
                };
            }
            catch (Exception ex)
            {
                return new UpdateTheaterResponse()
                {
                    Success = ex.Message
                };
            }
        }
    }
}
