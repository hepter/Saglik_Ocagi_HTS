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
    
    public partial class islem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public islem()
        {
            this.islemler = new HashSet<islemler>();
        }
    
        public int id { get; set; }
        public int islemid { get; set; }
        public string islemadi { get; set; }
        public string birimfiyat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<islemler> islemler { get; set; }
    }
}
