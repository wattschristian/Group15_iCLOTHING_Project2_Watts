//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Group15_iCLOTHINGApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Administrator
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Administrator()
        {
            this.OrderStatus = new HashSet<OrderStatus>();
        }
    
        public string adminID { get; set; }
        public string adminName { get; set; }
        public string adminEmail { get; set; }
        public System.DateTime dateHired { get; set; }
        public string adminEncryptedPassword { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderStatus> OrderStatus { get; set; }
        public virtual AboutUs AboutUs { get; set; }
    }
}
