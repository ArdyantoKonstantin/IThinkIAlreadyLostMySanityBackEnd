using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelContract.ResponseModel
{
    public class GetCinemaResponse
    {
        public List<CinemaDetails>? Cinemas { get; set; }
        public int TotalData { get; set; }
    }
}
