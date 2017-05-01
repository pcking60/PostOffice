namespace PostOfiice.DAta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ApplicationRoleGroups",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.GroupId, t.RoleId })
                .ForeignKey("dbo.ApplicationGroups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ApplicationRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(maxLength: 250),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.ApplicationRoles", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.ApplicationUserGroups",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.GroupId })
                .ForeignKey("dbo.ApplicationGroups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(maxLength: 256),
                        Address = c.String(maxLength: 256),
                        BirthDay = c.DateTime(),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        MetaKeyWord = c.String(),
                        MetaDescription = c.String(),
                        Status = c.Boolean(nullable: false),
                        POID = c.Int(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PostOffices", t => t.POID, cascadeDelete: true)
                .Index(t => t.POID);
            
            CreateTable(
                "dbo.ApplicationUserClaims",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.PostOffices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        POStyle = c.Int(),
                        POAddress = c.String(maxLength: 500),
                        POMobile = c.String(maxLength: 50),
                        DistrictID = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        MetaDescription = c.String(),
                        MetaKeyWord = c.String(),
                        Status = c.Boolean(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Districts", t => t.DistrictID, cascadeDelete: true)
                .Index(t => t.DistrictID);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        MetaDescription = c.String(),
                        MetaKeyWord = c.String(),
                        Status = c.Boolean(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PaymentMethod",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Value = c.Int(),
                        Description = c.String(maxLength: 500),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        MetaDescription = c.String(),
                        MetaKeyWord = c.String(),
                        Status = c.Boolean(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PropertyPOs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PropertyServices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ServiceID = c.Int(nullable: false),
                        PropertyPOID = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        MetaDescription = c.String(),
                        MetaKeyWord = c.String(),
                        Status = c.Boolean(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PropertyPOs", t => t.PropertyPOID, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceID, cascadeDelete: true)
                .Index(t => t.ServiceID)
                .Index(t => t.PropertyPOID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256),
                        GroupID = c.Int(nullable: false),
                        Unit = c.String(maxLength: 50, unicode: false),
                        BuyIn = c.Decimal(precision: 18, scale: 2),
                        SoldOut = c.Decimal(precision: 18, scale: 2),
                        VAT = c.Single(),
                        PayMethodID = c.Int(),
                        Description = c.String(maxLength: 256),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        MetaDescription = c.String(),
                        MetaKeyWord = c.String(),
                        Status = c.Boolean(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ServiceGroups", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.ServiceGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 500),
                        ParentID = c.Int(),
                        DisplayOrder = c.Int(),
                        Image = c.String(maxLength: 256),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        MetaDescription = c.String(),
                        MetaKeyWord = c.String(),
                        Status = c.Boolean(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TransactionDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TransactionID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Money = c.Decimal(precision: 18, scale: 2),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        MetaDescription = c.String(),
                        MetaKeyWord = c.String(),
                        Status = c.Boolean(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Transactions", t => t.TransactionID, cascadeDelete: true)
                .Index(t => t.TransactionID);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ServiceID = c.Int(nullable: false),
                        TransactionTypeID = c.Int(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        MetaDescription = c.String(),
                        MetaKeyWord = c.String(),
                        Status = c.Boolean(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Services", t => t.ServiceID, cascadeDelete: true)
                .ForeignKey("dbo.TransactionTypes", t => t.TransactionTypeID, cascadeDelete: true)
                .Index(t => t.ServiceID)
                .Index(t => t.TransactionTypeID);
            
            CreateTable(
                "dbo.TransactionTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VisitorStatictis",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        VisitedDate = c.DateTime(nullable: false),
                        IPAdress = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransactionDetails", "TransactionID", "dbo.Transactions");
            DropForeignKey("dbo.Transactions", "TransactionTypeID", "dbo.TransactionTypes");
            DropForeignKey("dbo.Transactions", "ServiceID", "dbo.Services");
            DropForeignKey("dbo.ApplicationUserRoles", "IdentityRole_Id", "dbo.ApplicationRoles");
            DropForeignKey("dbo.PropertyServices", "ServiceID", "dbo.Services");
            DropForeignKey("dbo.Services", "GroupID", "dbo.ServiceGroups");
            DropForeignKey("dbo.PropertyServices", "PropertyPOID", "dbo.PropertyPOs");
            DropForeignKey("dbo.ApplicationUserGroups", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUsers", "POID", "dbo.PostOffices");
            DropForeignKey("dbo.PostOffices", "DistrictID", "dbo.Districts");
            DropForeignKey("dbo.ApplicationUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUserGroups", "GroupId", "dbo.ApplicationGroups");
            DropForeignKey("dbo.ApplicationRoleGroups", "RoleId", "dbo.ApplicationRoles");
            DropForeignKey("dbo.ApplicationRoleGroups", "GroupId", "dbo.ApplicationGroups");
            DropIndex("dbo.Transactions", new[] { "TransactionTypeID" });
            DropIndex("dbo.Transactions", new[] { "ServiceID" });
            DropIndex("dbo.TransactionDetails", new[] { "TransactionID" });
            DropIndex("dbo.Services", new[] { "GroupID" });
            DropIndex("dbo.PropertyServices", new[] { "PropertyPOID" });
            DropIndex("dbo.PropertyServices", new[] { "ServiceID" });
            DropIndex("dbo.PostOffices", new[] { "DistrictID" });
            DropIndex("dbo.ApplicationUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUsers", new[] { "POID" });
            DropIndex("dbo.ApplicationUserGroups", new[] { "GroupId" });
            DropIndex("dbo.ApplicationUserGroups", new[] { "UserId" });
            DropIndex("dbo.ApplicationUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.ApplicationUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationRoleGroups", new[] { "RoleId" });
            DropIndex("dbo.ApplicationRoleGroups", new[] { "GroupId" });
            DropTable("dbo.VisitorStatictis");
            DropTable("dbo.TransactionTypes");
            DropTable("dbo.Transactions");
            DropTable("dbo.TransactionDetails");
            DropTable("dbo.ServiceGroups");
            DropTable("dbo.Services");
            DropTable("dbo.PropertyServices");
            DropTable("dbo.PropertyPOs");
            DropTable("dbo.PaymentMethod");
            DropTable("dbo.Errors");
            DropTable("dbo.Districts");
            DropTable("dbo.PostOffices");
            DropTable("dbo.ApplicationUserLogins");
            DropTable("dbo.ApplicationUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.ApplicationUserGroups");
            DropTable("dbo.ApplicationUserRoles");
            DropTable("dbo.ApplicationRoles");
            DropTable("dbo.ApplicationRoleGroups");
            DropTable("dbo.ApplicationGroups");
        }
    }
}
