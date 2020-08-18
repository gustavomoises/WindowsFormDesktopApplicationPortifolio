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
    
    public partial class WaitlistEntry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WaitlistEntry()
        {
            this.Tables = new HashSet<Table>();
        }
    
        public int WaitlistEntryID { get; set; }
        public int CustomerID { get; set; }
        public int RestaurantID { get; set; }
        public short PartySize { get; set; }
        public string WaitlistStatus { get; set; }
        public string EntryOrigin { get; set; }
        public System.DateTime CheckinDate { get; set; }
        public Nullable<System.DateTime> SeatingDate { get; set; }
        public Nullable<System.DateTime> CheckoutDate { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table> Tables { get; set; }
    }
}