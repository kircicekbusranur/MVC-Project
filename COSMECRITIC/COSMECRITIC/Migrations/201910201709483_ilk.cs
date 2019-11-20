namespace COSMECRITIC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ilk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AltKategoriler",
                c => new
                    {
                        AltKategoriID = c.Int(nullable: false, identity: true),
                        AltKategoriAdi = c.String(),
                        AltKategoriDurum = c.String(),
                        KategoriId = c.Int(nullable: false),
                        Markalar_MarkaID = c.Int(),
                    })
                .PrimaryKey(t => t.AltKategoriID)
                .ForeignKey("dbo.Kategoriler", t => t.KategoriId, cascadeDelete: true)
                .ForeignKey("dbo.Markalar", t => t.Markalar_MarkaID)
                .Index(t => t.KategoriId)
                .Index(t => t.Markalar_MarkaID);
            
            CreateTable(
                "dbo.Kategoriler",
                c => new
                    {
                        KategoriID = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(),
                        Aciklama = c.String(),
                        KategoriDurum = c.Int(nullable: false),
                        Markalar_MarkaID = c.Int(),
                    })
                .PrimaryKey(t => t.KategoriID)
                .ForeignKey("dbo.Markalar", t => t.Markalar_MarkaID)
                .Index(t => t.Markalar_MarkaID);
            
            CreateTable(
                "dbo.Urunler",
                c => new
                    {
                        UrunID = c.Int(nullable: false, identity: true),
                        AltKategoriId = c.Int(nullable: false),
                        MarkaId = c.Int(nullable: false),
                        UrunAdi = c.String(),
                        UrunFiyati = c.Double(nullable: false),
                        UrunAciklama = c.String(),
                        UrunDurum = c.Int(nullable: false),
                        Kategoriler_KategoriID = c.Int(),
                    })
                .PrimaryKey(t => t.UrunID)
                .ForeignKey("dbo.AltKategoriler", t => t.AltKategoriId, cascadeDelete: true)
                .ForeignKey("dbo.Markalar", t => t.MarkaId, cascadeDelete: true)
                .ForeignKey("dbo.Kategoriler", t => t.Kategoriler_KategoriID)
                .Index(t => t.AltKategoriId)
                .Index(t => t.MarkaId)
                .Index(t => t.Kategoriler_KategoriID);
            
            CreateTable(
                "dbo.Markalar",
                c => new
                    {
                        MarkaID = c.Int(nullable: false, identity: true),
                        MarkaAdi = c.String(),
                        MarkaAciklama = c.String(),
                        MarkaLogo = c.String(),
                    })
                .PrimaryKey(t => t.MarkaID);
            
            CreateTable(
                "dbo.OzellikDetay",
                c => new
                    {
                        OzellikID = c.Int(nullable: false, identity: true),
                        OzellikAdi = c.String(),
                        Aciklama = c.String(),
                    })
                .PrimaryKey(t => t.OzellikID);
            
            CreateTable(
                "dbo.Resimler",
                c => new
                    {
                        ResimID = c.Int(nullable: false, identity: true),
                        BuyukYol = c.String(),
                        OrtaYol = c.String(),
                        KucukYol = c.String(),
                        UrunId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResimID)
                .ForeignKey("dbo.Urunler", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.UrunId);
            
            CreateTable(
                "dbo.UrunOzellik",
                c => new
                    {
                        UrunId = c.Int(nullable: false),
                        OzellikId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UrunId, t.OzellikId })
                .ForeignKey("dbo.OzellikDetay", t => t.OzellikId, cascadeDelete: true)
                .ForeignKey("dbo.Urunler", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.UrunId)
                .Index(t => t.OzellikId);
            
            CreateTable(
                "dbo.UrunPuan",
                c => new
                    {
                        PuanID = c.Int(nullable: false),
                        UyeId = c.Int(nullable: false),
                        UrunId = c.Int(nullable: false),
                        PuanDegeri = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PuanID, t.UyeId, t.UrunId })
                .ForeignKey("dbo.Urunler", t => t.UrunId, cascadeDelete: true)
                .ForeignKey("dbo.Uyeler", t => t.UyeId, cascadeDelete: true)
                .Index(t => t.UyeId)
                .Index(t => t.UrunId);
            
            CreateTable(
                "dbo.Uyeler",
                c => new
                    {
                        UyeID = c.Int(nullable: false, identity: true),
                        UyeAdi = c.String(),
                        UyeSoyadi = c.String(),
                        UyeEmail = c.String(),
                        UyeParola = c.String(),
                        UyeDgtTarih = c.DateTime(nullable: false),
                        UyeDurum = c.Int(nullable: false),
                        UyeCinsiyet = c.String(),
                    })
                .PrimaryKey(t => t.UyeID);
            
            CreateTable(
                "dbo.UrunYorum",
                c => new
                    {
                        YorumId = c.Int(nullable: false),
                        UrunId = c.Int(nullable: false),
                        UyeId = c.Int(nullable: false),
                        YorumMetni = c.String(),
                        YorumTarih = c.DateTime(nullable: false),
                        YorumDurum = c.Int(nullable: false),
                        YorumBegeniSayisi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.YorumId, t.UrunId, t.UyeId })
                .ForeignKey("dbo.Urunler", t => t.UrunId, cascadeDelete: true)
                .ForeignKey("dbo.Uyeler", t => t.UyeId, cascadeDelete: true)
                .Index(t => t.UrunId)
                .Index(t => t.UyeId);
            
            CreateTable(
                "dbo.UyeFavoriListe",
                c => new
                    {
                        FavListeID = c.Int(nullable: false, identity: true),
                        UyeId = c.Int(nullable: false),
                        UrunId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FavListeID)
                .ForeignKey("dbo.Urunler", t => t.UrunId, cascadeDelete: true)
                .ForeignKey("dbo.Uyeler", t => t.UyeId, cascadeDelete: true)
                .Index(t => t.UyeId)
                .Index(t => t.UrunId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UrunPuan", "UyeId", "dbo.Uyeler");
            DropForeignKey("dbo.UyeFavoriListe", "UyeId", "dbo.Uyeler");
            DropForeignKey("dbo.UyeFavoriListe", "UrunId", "dbo.Urunler");
            DropForeignKey("dbo.UrunYorum", "UyeId", "dbo.Uyeler");
            DropForeignKey("dbo.UrunYorum", "UrunId", "dbo.Urunler");
            DropForeignKey("dbo.UrunPuan", "UrunId", "dbo.Urunler");
            DropForeignKey("dbo.UrunOzellik", "UrunId", "dbo.Urunler");
            DropForeignKey("dbo.UrunOzellik", "OzellikId", "dbo.OzellikDetay");
            DropForeignKey("dbo.Resimler", "UrunId", "dbo.Urunler");
            DropForeignKey("dbo.Urunler", "Kategoriler_KategoriID", "dbo.Kategoriler");
            DropForeignKey("dbo.Urunler", "MarkaId", "dbo.Markalar");
            DropForeignKey("dbo.Kategoriler", "Markalar_MarkaID", "dbo.Markalar");
            DropForeignKey("dbo.AltKategoriler", "Markalar_MarkaID", "dbo.Markalar");
            DropForeignKey("dbo.Urunler", "AltKategoriId", "dbo.AltKategoriler");
            DropForeignKey("dbo.AltKategoriler", "KategoriId", "dbo.Kategoriler");
            DropIndex("dbo.UyeFavoriListe", new[] { "UrunId" });
            DropIndex("dbo.UyeFavoriListe", new[] { "UyeId" });
            DropIndex("dbo.UrunYorum", new[] { "UyeId" });
            DropIndex("dbo.UrunYorum", new[] { "UrunId" });
            DropIndex("dbo.UrunPuan", new[] { "UrunId" });
            DropIndex("dbo.UrunPuan", new[] { "UyeId" });
            DropIndex("dbo.UrunOzellik", new[] { "OzellikId" });
            DropIndex("dbo.UrunOzellik", new[] { "UrunId" });
            DropIndex("dbo.Resimler", new[] { "UrunId" });
            DropIndex("dbo.Urunler", new[] { "Kategoriler_KategoriID" });
            DropIndex("dbo.Urunler", new[] { "MarkaId" });
            DropIndex("dbo.Urunler", new[] { "AltKategoriId" });
            DropIndex("dbo.Kategoriler", new[] { "Markalar_MarkaID" });
            DropIndex("dbo.AltKategoriler", new[] { "Markalar_MarkaID" });
            DropIndex("dbo.AltKategoriler", new[] { "KategoriId" });
            DropTable("dbo.UyeFavoriListe");
            DropTable("dbo.UrunYorum");
            DropTable("dbo.Uyeler");
            DropTable("dbo.UrunPuan");
            DropTable("dbo.UrunOzellik");
            DropTable("dbo.Resimler");
            DropTable("dbo.OzellikDetay");
            DropTable("dbo.Markalar");
            DropTable("dbo.Urunler");
            DropTable("dbo.Kategoriler");
            DropTable("dbo.AltKategoriler");
        }
    }
}
