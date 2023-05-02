using MarvelContract.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelContract.RequestModel
{
    public class GetCinemaRequest : IRequest<GetCinemaResponse>
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}
