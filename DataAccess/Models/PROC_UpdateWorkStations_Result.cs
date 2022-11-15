using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    [NotMapped]
    public class PROC_UpdateWorkStations_Result
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }
}
