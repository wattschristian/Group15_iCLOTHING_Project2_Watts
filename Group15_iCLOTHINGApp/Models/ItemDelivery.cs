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
    
    public partial class ItemDelivery
    {
        public string stickerID { get; set; }
        public System.DateTime stickerDate { get; set; }
        public string customerID { get; set; }
        public string productID { get; set; }
    
        public virtual CustomerInfo CustomerInfo { get; set; }
        public virtual Product Product { get; set; }
    }
}
