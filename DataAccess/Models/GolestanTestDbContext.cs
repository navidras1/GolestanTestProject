using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class GolestanTestDbContext : DbContext
{
    public GolestanTestDbContext()
    {
    }

    public GolestanTestDbContext(DbContextOptions<GolestanTestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<RetailStore> RetailStores { get; set; }

    public virtual DbSet<WorkStation> WorkStations { get; set; }

    
    public virtual DbSet<PROC_AddRetailStore_Result> PROC_AddRetailStore_Result { get; set; }
    public virtual DbSet<PROC_UpdateRetailStore_Result> PROC_UpdateRetailStore_Result { get; set; }
    public virtual DbSet<PROC_DeleteRetailStore_Result> PROC_DeleteRetailStore_Result { get; set; }
    public virtual DbSet<PROC_AddWorkStations_Result> PROC_AddWorkStations_Result { get; set; }
    public virtual DbSet<PROC_UpdateWorkStations_Result> PROC_UpdateWorkStations_Result { get; set; }
    public virtual DbSet<PROC_DeleteWorkStation_Result> PROC_DeleteWorkStation_Result { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {}//=> optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=GolestanTestDb;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PROC_AddRetailStore_Result>().HasNoKey().ToView("PROC_AddRetailStore_Result");
        modelBuilder.Entity<PROC_UpdateRetailStore_Result>().HasNoKey().ToView("PROC_UpdateRetailStore_Result");
        modelBuilder.Entity<PROC_DeleteRetailStore_Result>().HasNoKey().ToView("PROC_DeleteRetailStore_Result");
        modelBuilder.Entity<PROC_AddWorkStations_Result>().HasNoKey().ToView("PROC_AddWorkStations_Result");
        modelBuilder.Entity<PROC_UpdateWorkStations_Result>().HasNoKey().ToView("PROC_UpdateWorkStations_Result");
        modelBuilder.Entity<PROC_DeleteWorkStation_Result>().HasNoKey().ToView("PROC_DeleteWorkStation_Result");
        
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
