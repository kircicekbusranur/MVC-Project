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
    
    public partial class AltKategoriler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AltKategoriler()
        {
            this.Urunler = new HashSet<Urunler>();
        }
    
        public int AltKategoriID { get; set; }
        public string AltKategoriAdi { get; set; }
        public string AltKategoriDurum { get; set; }
        public int KategoriId { get; set; }
        public Nullable<int> Markalar_MarkaID { get; set; }
    
        public virtual Kategoriler Kategoriler { get; set; }
        public virtual Markalar Markalar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Urunler> Urunler { get; set; }
    }
}