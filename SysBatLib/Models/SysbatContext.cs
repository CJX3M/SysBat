using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SysbatLib.Models
{
    public class SysbatContext : DbContext
    {
        public DbSet<Objeto> Objetos { get; set; }
        public DbSet<Propiedad> Propiedades { get; set; }
        public DbSet<ObjetoValores> ObjetosValores { get; set; }
        public DbSet<PropiedadValores> PorpiedadesValores { get; set; }

        public SysbatContext() : base("DevConn"){}

        public SysbatContext(string connString) : base(connString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Objeto>()
                   .HasMany<Propiedad>(s => s.Propiedades)
                   .WithMany(c => c.Objetos)
                   .Map(cs =>
                   {
                       cs.MapLeftKey("ObjetoOid");
                       cs.MapRightKey("PropiedadOid");
                       cs.ToTable("ObjetoPropiedades");
                   });

            modelBuilder.Entity<ObjetoValores>()
                .HasRequired<Objeto>(o => o.Objeto)
                .WithMany(o => o.Valores)
                .HasForeignKey(o => o.ObjetoOid);

            modelBuilder.Entity<PropiedadValores>()
                .HasRequired<ObjetoValores>(o => o.Objeto)
                .WithMany(o => o.Valores)
                .HasForeignKey(o => o.ObjetoOid);

            modelBuilder.Entity<PropiedadValores>()
                .HasRequired<Propiedad>(o => o.Propiedad)
                .WithMany(o => o.Valores)
                .HasForeignKey(o => o.ObjetoOid);

            base.OnModelCreating(modelBuilder);
        }
    }
}