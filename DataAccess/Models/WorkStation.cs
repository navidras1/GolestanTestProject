using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public partial class WorkStation
{
    public int Id { get; set; }

    public Guid? RetailStoreId { get; set; }

    [MaxLength(100)]
    public string? Name { get; set; }

    [MaxLength(100)]
    public string? Location { get; set; }

    public bool? IsActive { get; set; }

    public virtual RetailStore? RetailStore { get; set; }
}
