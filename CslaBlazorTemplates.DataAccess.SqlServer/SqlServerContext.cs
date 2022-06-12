using CslaBlazorTemplates.DataAccess.SqlServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CslaBlazorTemplates.DataAccess.SqlServer
{
    /// <summary>
    /// Defines the context of the SQL Server.
    /// </summary>
    public class SqlServerContext : DbContext
    {
        #region Entity sets

        public DbSet<Team>? Teams { get; set; }
        public DbSet<Player>? Players { get; set; }
        public DbSet<Folder>? Folders { get; set; }
        public DbSet<Group>? Groups { get; set; }
        public DbSet<Person>? Persons { get; set; }
        public DbSet<GroupPerson>? GroupPersons { get; set; }

        #endregion

        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="options">The options to be used by DbContext.</param>
        public SqlServerContext(
            DbContextOptions<SqlServerContext> options
            ) : base(options)
        { }

        /// <summary>
        /// Configure the model discovered by convention from the entity type..
        /// </summary>
        /// <param name="builder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(
            ModelBuilder builder
            )
        {
            base.OnModelCreating(builder);

            #region Team

            builder.Entity<Team>()
                .HasIndex(e => e.TeamCode)
                .IsUnique();
            builder.Entity<Team>()
                .Property(e => e.Timestamp)
                .HasDefaultValue(DateTime.Now);

            #endregion

            #region Player

            builder.Entity<Player>()
                .HasIndex(e => new { e.TeamKey, e.PlayerCode })
                .IsUnique();

            #endregion

            #region Folder

            builder.Entity<Folder>()
                .HasIndex(e => new { e.ParentKey, e.FolderOrder });
            builder.Entity<Folder>()
                .Property(e => e.Timestamp)
                .HasDefaultValue(DateTime.Now);

            #endregion

            #region Group

            builder.Entity<Group>()
                .HasIndex(e => e.GroupCode)
                .IsUnique();
            builder.Entity<Group>()
                .Property(e => e.Timestamp)
                .HasDefaultValue(DateTime.Now);

            #endregion

            #region Person

            builder.Entity<Person>()
                .HasIndex(e => e.PersonCode)
                .IsUnique();
            builder.Entity<Person>()
                .Property(e => e.Timestamp)
                .HasDefaultValue(DateTime.Now);

            #endregion

            #region GroupPerson

            builder.Entity<GroupPerson>()
                .HasKey(e => new { e.GroupKey, e.PersonKey })
                .IsClustered();

            #endregion
        }

        #region Auto update timestamps

        void SubscribeStateChangeEvents()
        {
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            ChangeTracker.Tracked += OnEntityTracked;
            ChangeTracker.StateChanged += OnEntityStateChanged;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
        }

        void OnEntityStateChanged(object sender, EntityStateChangedEventArgs e)
        {
            ProcessLastModified(e.Entry);
        }

        void OnEntityTracked(object sender, EntityTrackedEventArgs e)
        {
            if (!e.FromQuery)
                ProcessLastModified(e.Entry);
        }

        void ProcessLastModified(EntityEntry entry)
        {
            if (entry.State == EntityState.Modified || entry.State == EntityState.Added)
            {
                var property = entry.Metadata.FindProperty("Timestamp");
                if (property != null && property.ClrType == typeof(DateTime))
                    entry.CurrentValues[property] = DateTime.UtcNow;
            }
        }

        #endregion
    }
}
