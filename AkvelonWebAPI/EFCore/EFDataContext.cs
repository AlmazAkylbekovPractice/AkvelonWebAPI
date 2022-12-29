using System;
using Microsoft.EntityFrameworkCore;

namespace AkvelonWebAPI.EFCore
{
	public class EFDataContext : DbContext
	{
        public EFDataContext(DbContextOptions<EFDataContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}

