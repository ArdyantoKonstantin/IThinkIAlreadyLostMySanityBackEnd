using MarvelContract.RequestModel;
using MarvelContract.ResponseModel;
using MarvelEntity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelServices.RequestService
{
    public class RegisterCinemaHandler : IRequestHandler<RegisterCinemaRequest, RegisterCinemaResponse>
    {
        ExamDbContext _db;

        public RegisterCinemaHandler(ExamDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<RegisterCinemaResponse> Handle(RegisterCinemaRequest request, CancellationToken cancellationToken)
        {
            var newCinema = new Cinema()
            {
                Id = Ulid.NewUlid().ToString(),
                Name = request.Name,
                Address = request.Address,
                BlobId = request.BlobId
            };
            _db.Cinemas.Add(newCinema);
            try
            {
                await _db.SaveChangesAsync();
                return new RegisterCinemaResponse()
                {
                    Success = "Success"
                };
            }
            catch(Exception ex)
            {
                return new RegisterCinemaResponse()
                {
                    Success = ex.Message
                };
            }
        }
    }
}
