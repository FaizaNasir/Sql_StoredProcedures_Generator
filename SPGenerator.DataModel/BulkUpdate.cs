//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SPGenerator.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class BulkUpdate
    {
        public int BulkUpdateID { get; set; }
        public Nullable<int> AccountID { get; set; }
        public Nullable<int> ContactID { get; set; }
        public Nullable<int> New_Column { get; set; }
        public Nullable<System.DateTime> DateRangeStart { get; set; }
        public Nullable<System.DateTime> DateRangeEnd { get; set; }
        public Nullable<decimal> TotalAmountRangeStart { get; set; }
        public Nullable<decimal> TotalAmountRangeEnd { get; set; }
    }
}
