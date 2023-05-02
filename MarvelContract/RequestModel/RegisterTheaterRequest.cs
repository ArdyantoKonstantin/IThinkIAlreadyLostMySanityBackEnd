using MarvelContract.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelContract.RequestModel
{
    public class RegisterTheaterRequest : IRequest<RegisterTheaterResponse>
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string CinemaId { get; set; } = string.Empty;

        public string TheaterTypeId { get; set; } = string.Empty;
    }
}
