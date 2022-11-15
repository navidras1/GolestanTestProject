using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    [NotMapped]
    public class PROC_AddWorkStations_Result
    {
        public bool IsSuccessful { get; set; }
        public int TheId { get; set; }
        public string Message { get; set; }
    }
}
