namespace Dalek_Mint.DataAccess
{
    using Dalek_Mint.Models;
    using System.Data.Entity;

    /// <summary>
    /// Defines the <see cref="MintContext" />
    /// </summary>
    public class MintContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MintContext"/> class.
        /// </summary>
        public MintContext() : base("MintContext")
        {
        }

        /// <summary>
        /// The OnModelCreating
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder<see cref="DbModelBuilder"/></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MintContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Gets or sets the Campus database model.
        /// </summary>
        public DbSet<Campus> Campus { get; set; }

        /// <summary>
        /// Gets or sets the CampusEvent database model.
        /// </summary>
        public DbSet<CampusEvent> CampusEvent { get; set; }

        /// <summary>
        /// Gets or sets the Club database model.
        /// </summary>
        public DbSet<Club> Club { get; set; }

        /// <summary>
        /// Gets or sets the ClubMember database model.
        /// </summary>
        public DbSet<ClubMember> ClubMember { get; set; }

        /// <summary>
        /// Gets or sets the ClubNews database model.
        /// </summary>
        public DbSet<ClubNews> ClubNews { get; set; }

        /// <summary>
        /// Gets or sets the Event database model.
        /// </summary>
        public DbSet<Event> Event { get; set; }

        /// <summary>
        /// Gets or sets the Event database model.
        /// </summary>
        public DbSet<Category> Category { get; set; }

        /// <summary>
        /// Gets or sets the EventAttendance database model.
        /// </summary>
        public DbSet<EventAttendance> EventAttendance { get; set; }

        /// <summary>
        /// Gets or sets the EventHost database model.
        /// </summary>
        public DbSet<EventHost> EventHost { get; set; }

        /// <summary>
        /// Gets or sets the News database model.
        /// </summary>
        public DbSet<News> News { get; set; }

        /// <summary>
        /// Gets or sets the PermissionSet database model.
        /// </summary>
        public DbSet<PermissionSet> PermissionSet { get; set; }

        /// <summary>
        /// Gets or sets the User database model.
        /// </summary>
        public DbSet<User> User { get; set; }

        /// <summary>
        /// Gets or sets the UserGroup database model.
        /// </summary>
        public DbSet<UserGroup> UserGroup { get; set; }
    }
}
