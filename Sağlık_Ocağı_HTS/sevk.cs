//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sağlık_Ocağı_HTS
{
    using System;
    using System.Collections.Generic;
    
    public partial class sevk
    {
        public System.DateTime sevktarihi { get; set; }
        public int dosyaid { get; set; }
        public int sevkedendoktorid { get; set; }
        public string poliklinik { get; set; }
        public string sira { get; set; }
        public string saat { get; set; }
        public int taburcuid { get; set; }
    
        public virtual doktor doktor { get; set; }
        public virtual dosya dosya { get; set; }
        public virtual poliklinik poliklinik1 { get; set; }
        public virtual taburcu taburcu { get; set; }
    }
}
