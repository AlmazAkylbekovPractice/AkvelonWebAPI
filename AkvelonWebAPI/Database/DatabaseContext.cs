using System;
using Microsoft.EntityFrameworkCore;

namespace AkvelonWebAPI.EFCore
{
	public class DatabaseContext : DbContext
	{
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}

