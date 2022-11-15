using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public partial class RetailStore
{
    public Guid Id { get; set; }

    [MaxLength(100)]
    public string? Name { get; set; }
    [MaxLength(80)]
    public string? Address { get; set; }

    [MaxLength(15)]
    public string? Ipaddress { get; set; }
    
    public DateTime? OpeningDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsTell { get; set; }

    public Guid? ParenetId { get; set; }

    public virtual ICollection<RetailStore> InverseParenet { get; } = new List<RetailStore>();

    public virtual RetailStore? Parenet { get; set; }

    public virtual ICollection<WorkStation> Children { get; } = new List<WorkStation>();
}
