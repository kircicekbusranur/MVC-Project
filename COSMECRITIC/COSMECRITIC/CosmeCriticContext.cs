namespace COSMECRITIC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class CosmeCriticContext : DbContext
    {

        public CosmeCriticContext()
            : base("name=Baglanti")
        {
        }

        public virtual DbSet<Urunler> Urunler { get; set; }
        public virtual DbSet<Kategoriler> Kategoriler { get; set; }
        public virtual DbSet<AltKategoriler> AltKategoriler { get; set; }
        public virtual DbSet<Resimler> Resimler { get; set; }
        public virtual DbSet<Markalar> Markalar { get; set; }
        public virtual DbSet<UrunOzellik> UrunOzellik { get; set; }
        public virtual DbSet<OzellikDetay> OzellikDetay { get; set; }
        public virtual DbSet<UrunYorum> UrunYorum { get; set; }
        public virtual DbSet<Uyeler> Uyeler { get; set; }
        public virtual DbSet<UyeFavoriListe> UyeFavoriListe { get; set; }
        public virtual DbSet<UrunPuan> UrunPuan { get; set; }
    }
    [Table("Urunler")]
    public class Urunler
    {
        [Key]
        public int UrunID { get; set; }
        public int AltKategoriId { get; set; }
        public int MarkaId { get; set; }
        public string UrunAdi { get; set; }
        public double UrunFiyati { get; set; }
        public string UrunAciklama { get; set; }
        public int UrunDurum { get; set; }

        [ForeignKey("AltKategoriId")]
        public virtual AltKategoriler AltKategoriler { get; set; }
        [ForeignKey("MarkaId")]
        public virtual Markalar Markalar { get; set; }

    }
    [Table("Kategoriler")]
    public class Kategoriler
    {
        [Key]
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }
        public int KategoriDurum { get; set; }

        public Kategoriler()
        {
            AltKategoriler = new HashSet<AltKategoriler>();
            Urunler = new HashSet<Urunler>();
        }

        public virtual ICollection<AltKategoriler> AltKategoriler { get; set; }
        public virtual ICollection<Urunler> Urunler { get; set; }
    }
    [Table("AltKategoriler")]
    public class AltKategoriler
    {
        [Key]
        public int AltKategoriID { get; set; }
        public string AltKategoriAdi { get; set; }
        public string AltKategoriDurum { get; set; }
        public int KategoriId { get; set; }

        [ForeignKey("KategoriId")]
        public virtual Kategoriler Kategoriler { get; set; }

        public AltKategoriler()
        {
            Urunler = new HashSet<Urunler>();
        }
        public virtual ICollection<Urunler> Urunler { get; set; }

    }
    [Table("Resimler")]
    public class Resimler
    {
        [Key]
        public int ResimID { get; set; }
        public string BuyukYol { get; set; }
        public string OrtaYol { get; set; }
        public string KucukYol { get; set; }
        public int UrunId { get; set; }

        [ForeignKey("UrunId")]
        public virtual Urunler Urunler { get; set; }
    }
    [Table("Markalar")]
    public class Markalar
    {
        [Key]
        public int MarkaID { get; set; }
        public string MarkaAdi { get; set; }
        public string MarkaAciklama { get; set; }
        public string MarkaLogo { get; set; }

        public Markalar()
        {
            Urunler = new HashSet<Urunler>();
            Kategoriler = new HashSet<Kategoriler>();
            AltKategoriler = new HashSet<AltKategoriler>();
        }

        public virtual ICollection<Urunler> Urunler { get; set; }
        public virtual ICollection<Kategoriler> Kategoriler { get; set; }
        public virtual ICollection<AltKategoriler> AltKategoriler { get; set; }

    }
    [Table("UrunOzellik")]
    public class UrunOzellik
    {
        [Key]
        [Column(Order = 1)]
        public int UrunId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int OzellikId { get; set; }

        [ForeignKey("UrunId")]
        public virtual Urunler Urunler { get; set; }
        [ForeignKey("OzellikId")]
        public virtual OzellikDetay OzellikDetay { get; set; }

    }
    [Table("OzellikDetay")]
    public class OzellikDetay
    {
        [Key]
        public int OzellikID { get; set; }
        public string OzellikAdi { get; set; }
        public string Aciklama { get; set; }

    }
    [Table("UrunYorum")]
    public class UrunYorum
    {

        [Key]
        [Column(Order = 1)]
        public int YorumId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int UrunId { get; set; }
        [Key]
        [Column(Order = 3)]
        public int UyeId { get; set; }
        public string YorumMetni { get; set; }
        public DateTime YorumTarih { get; set; }
        public int YorumDurum { get; set; }
        public int YorumBegeniSayisi { get; set; }

        [ForeignKey("UrunId")]
        public virtual Urunler Urunler { get; set; }
        [ForeignKey("UyeId")]
        public virtual Uyeler Uyeler { get; set; }

    }
    [Table("Uyeler")]
    public class Uyeler
    {
        [Key]
        public int UyeID { get; set; }
        public string UyeAdi { get; set; }
        public string UyeSoyadi { get; set; }
        public string UyeEmail { get; set; }
        public string UyeParola { get; set; }
        public DateTime UyeDgtTarih { get; set; }
        public int UyeDurum { get; set; }
        public string UyeCinsiyet { get; set; }

        public Uyeler()
        {
            UrunYorum = new HashSet<UrunYorum>();
            UyeFavoriListe = new HashSet<UyeFavoriListe>();
        }
        public virtual ICollection<UrunYorum> UrunYorum { get; set; }
        public virtual ICollection<UyeFavoriListe> UyeFavoriListe { get; set; }
    }
    [Table("UyeFavoriListe")]
    public class UyeFavoriListe
    {
        [Key]
        public int FavListeID { get; set; }
        public int UyeId { get; set; }
        public int UrunId { get; set; }

        [ForeignKey("UyeId")]
        public virtual Uyeler Uyeler { get; set; }
        [ForeignKey("UrunId")]
        public virtual Urunler Urunler { get; set; }
    }
    [Table("UrunPuan")]
    public class UrunPuan
    {
        [Key]
        [Column(Order = 1)]
        public int PuanID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int UyeId { get; set; }
        [Key]
        [Column(Order = 3)]
        public int UrunId { get; set; }
        public int PuanDegeri { get; set; }

        [ForeignKey("UyeId")]
        public virtual Uyeler Uyeler { get; set; }
        [ForeignKey("UrunId")]
        public virtual Urunler Urunler { get; set; }
    }
}