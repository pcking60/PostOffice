namespace PostOfiice.DAta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSomeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Percents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        MetaDescription = c.String(),
                        MetaKeyWord = c.String(),
                        Status = c.Boolean(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        PercentId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        MetaDescription = c.String(),
                        MetaKeyWord = c.String(),
                        Status = c.Boolean(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Percents", t => t.PercentId, cascadeDelete: true)
                .Index(t => t.PercentId);
            
            CreateTable(
                "dbo.ServiceDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceId = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        MetaDescription = c.String(),
                        MetaKeyWord = c.String(),
                        Status = c.Boolean(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.PropertyId);
            
            AddColumn("dbo.TransactionDetails", "ServiceDetailId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceDetails", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.ServiceDetails", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.Properties", "PercentId", "dbo.Percents");
            DropIndex("dbo.ServiceDetails", new[] { "PropertyId" });
            DropIndex("dbo.ServiceDetails", new[] { "ServiceId" });
            DropIndex("dbo.Properties", new[] { "PercentId" });
            DropColumn("dbo.TransactionDetails", "ServiceDetailId");
            DropTable("dbo.ServiceDetails");
            DropTable("dbo.Properties");
            DropTable("dbo.Percents");
        }
    }
}
