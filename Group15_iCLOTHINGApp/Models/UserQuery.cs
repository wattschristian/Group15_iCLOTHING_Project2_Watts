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
    
    public partial class UserQuery
    {
        public string queryNo { get; set; }
        public System.DateTime queryDate { get; set; }
        public string queryDescription { get; set; }
        public string customerID { get; set; }
    
        public virtual CustomerInfo CustomerInfo { get; set; }
    }
}
