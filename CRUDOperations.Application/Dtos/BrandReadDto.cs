using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOperations.Infrastructure.Dtos
{
    public class BrandReadDto
    {
        public int BrandIdpk { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public int? IsActive { get; set; }
    }
}
