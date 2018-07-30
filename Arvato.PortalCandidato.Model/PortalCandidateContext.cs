namespace Arvato.PortalCandidato.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PortalCandidatoContext : DbContext
    {
        public PortalCandidatoContext()
            : base("name=PortalCandidatoContext")
        {
        }

        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()
                .Property(e => e.User)
                .IsUnicode(false);

            modelBuilder.Entity<Region>()
                .Property(e => e.User)
                .IsUnicode(false);
        }
    }
}
