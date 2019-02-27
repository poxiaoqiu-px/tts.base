using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using tts.business.core;
using tts.extends.entityframework;

namespace tts.business.entityframework
{
    public class BusinessDbContext : BaseDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public BusinessDbContext(DbContextOptions<BusinessDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
#if DEBUG
            //TODO:需要刷注释才开启
            //var updater = new DbDescriptionUpdater<BusinessDbContext>(this);
            //updater.UpdateDatabaseDescriptions();
#endif
        }
    }
}
