namespace Dalek_Mint.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Defines the <see cref="Configuration" />
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<Dalek_Mint.DataAccess.MintContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Dalek_Mint.DataAccess.MintContext";
        }

        /// <summary>
        /// The Seed
        /// </summary>
        /// <param name="context">The context<see cref="Dalek_Mint.DataAccess.MintContext"/></param>
        protected override void Seed(Dalek_Mint.DataAccess.MintContext context)
        {
        }
    }
}
