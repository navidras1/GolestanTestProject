using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ActivityModels
{
    public class UpdateRetailModel
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? Ipaddress { get; set; }

        public DateTime? OpeningDate { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsTell { get; set; }
    }
}
