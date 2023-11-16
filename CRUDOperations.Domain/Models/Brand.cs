using System.Security.Claims;

namespace CRUDOperations.Models
{
    public class Brand
    {
        public int BrandIdpk { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public int? IsActive { get; set; }
    }

}
