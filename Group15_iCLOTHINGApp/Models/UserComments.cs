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
    
    public partial class UserComments
    {
        public string commentNo { get; set; }
        public System.DateTime commentDate { get; set; }
        public string commentDescription { get; set; }
        public string customerID { get; set; }
    
        public virtual CustomerInfo CustomerInfo { get; set; }
    }
}
