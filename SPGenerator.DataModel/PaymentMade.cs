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
    
    public partial class PaymentMade
    {
        public int PaymentMadeID { get; set; }
        public Nullable<int> VendorID { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
        public Nullable<int> PaymentTermID { get; set; }
        public Nullable<int> PaidThroughID { get; set; }
        public string ReferenceNo { get; set; }
        public Nullable<bool> TaxDeducted { get; set; }
        public Nullable<int> UnpaidBillID { get; set; }
        public Nullable<int> PaymentTotalMadeID { get; set; }
        public string Notes { get; set; }
    }
}
