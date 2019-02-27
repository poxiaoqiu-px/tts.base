using System;
using System.Threading;
using System.Threading.Tasks;
using Abp.EntityFrameworkCore;
using Castle.LoggingFacility.MsLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace tts.extends.entityframework
{
    public abstract class BaseDbContext : AbpDbContext
    {

#if DEBUG
        public ILoggerFactory MsLoggerFactory { get; set; }
        public Castle.Core.Logging.ILoggerFactory CastleLoggerFactory { get; set; }
#endif

        public BaseDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            if (MsLoggerFactory != null && CastleLoggerFactory != null)
            {
                optionsBuilder.UseLoggerFactory(MsLoggerFactory)
                    .EnableSensitiveDataLogging();
            }
#endif
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                builder.Entity(entityType.ClrType).HasQueryFilter(SoftDeleteExpressionBuilder.Build(entityType));

                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(bool))
                    {
                        property.SetValueConverter(new BoolToIntConverter());
                    }
                }
            }
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues[nameof(BaseEntity.CreateUser)] = "";// HttpContext.Current.GetCurrentUserCode();
                        entry.CurrentValues[nameof(BaseEntity.CreateTime)] = DateTime.Now;
                        entry.CurrentValues[nameof(BaseEntity.DeleteFlag)] = "";
                        break;

                    case EntityState.Modified:
                        entry.CurrentValues[nameof(BaseEntity.ModifyUser)] = "";//HttpContext.Current.GetCurrentUserCode();
                        entry.CurrentValues[nameof(BaseEntity.ModifyTime)] = DateTime.Now;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues[nameof(BaseEntity.ModifyUser)] = "";//HttpContext.Current.GetCurrentUserCode();
                        entry.CurrentValues[nameof(BaseEntity.ModifyTime)] = DateTime.Now;
                        entry.CurrentValues[nameof(BaseEntity.DeleteFlag)] = "X";
                        break;
                }
            }
        }

    }
}
