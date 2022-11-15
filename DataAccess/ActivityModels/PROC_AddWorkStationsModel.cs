using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ActivityModels
{
    public class PROC_AddWorkStationsModel
    {
        public Guid RetailStoreId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool IsActive { get; set; }

    }
}
