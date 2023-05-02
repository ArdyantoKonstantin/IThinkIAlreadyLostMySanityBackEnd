using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelContract.ResponseModel
{
    public class TheaterDetails 
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CinemaName { get; set; } = string.Empty;
        public string TheaterType { get; set; } = string.Empty;
    }
}
