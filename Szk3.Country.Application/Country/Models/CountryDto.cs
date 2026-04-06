using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szk3.Country.Application.Country.Models
{
    public class CountryDto
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public required string Code { get; init; }
        public bool IsActive { get; init; }
       
    }
}
