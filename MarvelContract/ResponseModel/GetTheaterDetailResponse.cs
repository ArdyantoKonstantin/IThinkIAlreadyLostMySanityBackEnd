using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelContract.ResponseModel
{
    public class GetTheaterDetailResponse
    {
        public string? TypeId { get; set; }
        public string? TypeName { get; set; }
        public string? CinemaId { get; set; }
        public string? CinemaName { get; set; }
    }
}
