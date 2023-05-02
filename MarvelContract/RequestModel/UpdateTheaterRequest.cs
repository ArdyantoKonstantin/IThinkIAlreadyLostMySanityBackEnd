using MarvelContract.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelContract.RequestModel
{
    public class UpdateTheaterRequest : IRequest<UpdateTheaterResponse>
    {
        public int Id { get; set; }
        public string CinemaId { get; set; } = string.Empty;
        public string TypeId { get; set; } = string.Empty;
    }
}
