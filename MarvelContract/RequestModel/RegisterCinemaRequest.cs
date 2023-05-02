using MarvelContract.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelContract.RequestModel
{
    public class RegisterCinemaRequest : IRequest<RegisterCinemaResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Guid? BlobId { get; set; }
    }
}
