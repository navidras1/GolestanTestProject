using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    [NotMapped]
    public class PROC_UpdateRetailStore_Result
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }
}
