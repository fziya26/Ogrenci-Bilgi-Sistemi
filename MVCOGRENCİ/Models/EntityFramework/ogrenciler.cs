//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCOGRENCİ.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class ogrenciler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ogrenciler()
        {
            this.notlar = new HashSet<notlar>();
        }
    
        public int ogrenci_id { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string foto { get; set; }
        public string cinsiyet { get; set; }
        public Nullable<byte> kulup { get; set; }
    
        public virtual kulupler kulupler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<notlar> notlar { get; set; }
    }
}
