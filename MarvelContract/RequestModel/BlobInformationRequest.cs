using MarvelContract.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelContract.RequestModel
{
    public class BlobInformationRequest : IRequest<BlobInformationResponse>
    {
        public Guid Id { get; set; }
        public string? FileName { get; set; }
        public string? Mime { get; set; }
    }
}
