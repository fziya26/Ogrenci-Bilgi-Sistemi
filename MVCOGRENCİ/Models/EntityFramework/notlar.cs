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
    
    public partial class notlar
    {
        public int not_id { get; set; }
        public Nullable<byte> ders_id { get; set; }
        public Nullable<int> ogrenci_id { get; set; }
        public Nullable<byte> sinav1_notu { get; set; }
        public Nullable<byte> sinav2_notu { get; set; }
        public Nullable<byte> sinav3_notu { get; set; }
        public Nullable<byte> proje_notu { get; set; }
        public Nullable<decimal> ortalama { get; set; }
        public Nullable<bool> durum { get; set; }
    
        public virtual dersler dersler { get; set; }
        public virtual ogrenciler ogrenciler { get; set; }
    }
}
