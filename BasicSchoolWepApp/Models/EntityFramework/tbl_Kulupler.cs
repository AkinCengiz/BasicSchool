//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BasicSchoolWepApp.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Kulupler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Kulupler()
        {
            this.tbl_Ogrenciler = new HashSet<tbl_Ogrenciler>();
        }
    
        public int KulupId { get; set; }
        public string KulupAd { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Ogrenciler> tbl_Ogrenciler { get; set; }
    }
}