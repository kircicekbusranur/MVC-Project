//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CosmeCritic.Client.Models.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Urunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urunler()
        {
            this.Resimler = new HashSet<Resimler>();
            this.UrunPuan = new HashSet<UrunPuan>();
            this.UrunYorum = new HashSet<UrunYorum>();
            this.UyeFavoriListe = new HashSet<UyeFavoriListe>();
            this.OzellikDetay = new HashSet<OzellikDetay>();
        }
    
        public int UrunID { get; set; }
        public int AltKategoriId { get; set; }
        public int MarkaId { get; set; }
        public string UrunAdi { get; set; }
        public double UrunFiyati { get; set; }
        public string UrunAciklama { get; set; }
        public int UrunDurum { get; set; }
        public Nullable<int> Kategoriler_KategoriID { get; set; }
    
        public virtual AltKategoriler AltKategoriler { get; set; }
        public virtual Kategoriler Kategoriler { get; set; }
        public virtual Markalar Markalar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Resimler> Resimler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UrunPuan> UrunPuan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UrunYorum> UrunYorum { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UyeFavoriListe> UyeFavoriListe { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OzellikDetay> OzellikDetay { get; set; }
    }
}
