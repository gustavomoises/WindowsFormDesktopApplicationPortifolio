//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TableReadyADO
{
    using System;
    using System.Collections.Generic;
    
    public partial class RestaurantOwner
    {
        public int RestaurantId { get; set; }
        public int OwnerID { get; set; }
        public string Status { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public bool Active { get; set; }
        public bool Request { get; set; }
        public string RequestStatus { get; set; }
    
        public virtual Owner Owner { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}