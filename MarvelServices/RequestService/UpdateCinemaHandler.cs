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
    public class UpdateCinemaHandler : IRequestHandler<UpdateCinemaRequest, UpdateCinemaResponse>
    {
        ExamDbContext _db;

        public UpdateCinemaHandler(ExamDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<UpdateCinemaResponse> Handle(UpdateCinemaRequest request, CancellationToken cancellationToken)
        {
            var update = await _db.Cinemas.Where(Q => Q.Id == request.Id).FirstOrDefaultAsync();
            if (update == null)
            {
                return new UpdateCinemaResponse()
                {
                    Success = "Not found"
                };
            }

            update.Address = request.Address;
            update.BlobId = request.BlobId;
            try
            {
                await _db.SaveChangesAsync();
                return new UpdateCinemaResponse()
                {
                    Success = "success"
                };
            }
            catch (Exception ex)
            {
                return new UpdateCinemaResponse()
                {
                    Success = ex.Message
                };
            }
        }
    }
}
