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
    
    public partial class tbl_Dersler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Dersler()
        {
            this.tbl_Notlar = new HashSet<tbl_Notlar>();
        }
    
        public byte DersId { get; set; }
        public string DersAd { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Notlar> tbl_Notlar { get; set; }
    }
}
