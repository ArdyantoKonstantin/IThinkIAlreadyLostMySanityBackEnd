using MarvelContract.RequestModel;
using MarvelContract.ResponseModel;
using MarvelEntity.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelServices.RequestService
{
    public class RegisterTheaterHandler : IRequestHandler<RegisterTheaterRequest, RegisterTheaterResponse>
    {
        ExamDbContext _db;
        public RegisterTheaterHandler(ExamDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<RegisterTheaterResponse> Handle(RegisterTheaterRequest request, CancellationToken cancellationToken)
        {
            var newTheater = new Theater()
            {
                Name = request.Name,
                CinemaId = request.CinemaId,
                TheaterTypeId = request.TheaterTypeId
            };
            _db.Theaters.Add(newTheater);
            try
            {

                await _db.SaveChangesAsync();
                return new RegisterTheaterResponse()
                {
                    Success = "Success"
                };
            }
            catch (Exception ex)
            {
                return new RegisterTheaterResponse()
                {
                    Success = ex.Message
                };
            }
        }
    }
}
