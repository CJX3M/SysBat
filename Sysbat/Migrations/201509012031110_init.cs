namespace Sysbat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Objeto",
                c => new
                    {
                        Oid = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Oid);
            
            CreateTable(
                "dbo.Propiedad",
                c => new
                    {
                        Oid = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.Oid);
            
            CreateTable(
                "dbo.PropiedadValores",
                c => new
                    {
                        Oid = c.Int(nullable: false, identity: true),
                        Valor = c.String(),
                        ObjetoOid = c.Int(nullable: false),
                        PropiedadOid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Oid)
                .ForeignKey("dbo.ObjetoValores", t => t.ObjetoOid, cascadeDelete: true)
                .ForeignKey("dbo.Propiedad", t => t.PropiedadOid, cascadeDelete: true)
                .Index(t => t.ObjetoOid)
                .Index(t => t.PropiedadOid);
            
            CreateTable(
                "dbo.ObjetoValores",
                c => new
                    {
                        Oid = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        ObjetoOid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Oid)
                .ForeignKey("dbo.Objeto", t => t.ObjetoOid, cascadeDelete: true)
                .Index(t => t.ObjetoOid);
            
            CreateTable(
                "dbo.ObjetoPropiedades",
                c => new
                    {
                        ObjetoOid = c.Int(nullable: false),
                        PropiedadOid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ObjetoOid, t.PropiedadOid })
                .ForeignKey("dbo.Objeto", t => t.ObjetoOid, cascadeDelete: true)
                .ForeignKey("dbo.Propiedad", t => t.PropiedadOid, cascadeDelete: true)
                .Index(t => t.ObjetoOid)
                .Index(t => t.PropiedadOid);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ObjetoPropiedades", new[] { "PropiedadOid" });
            DropIndex("dbo.ObjetoPropiedades", new[] { "ObjetoOid" });
            DropIndex("dbo.ObjetoValores", new[] { "ObjetoOid" });
            DropIndex("dbo.PropiedadValores", new[] { "ObjetoOid" });
            DropIndex("dbo.PropiedadValores", new[] { "ObjetoOid" });
            DropForeignKey("dbo.ObjetoPropiedades", "PropiedadOid", "dbo.Propiedad");
            DropForeignKey("dbo.ObjetoPropiedades", "ObjetoOid", "dbo.Objeto");
            DropForeignKey("dbo.ObjetoValores", "ObjetoOid", "dbo.Objeto");
            DropForeignKey("dbo.PropiedadValores", "ObjetoOid", "dbo.Propiedad");
            DropForeignKey("dbo.PropiedadValores", "ObjetoOid", "dbo.ObjetoValores");
            DropTable("dbo.ObjetoPropiedades");
            DropTable("dbo.ObjetoValores");
            DropTable("dbo.PropiedadValores");
            DropTable("dbo.Propiedad");
            DropTable("dbo.Objeto");
        }
    }
}
