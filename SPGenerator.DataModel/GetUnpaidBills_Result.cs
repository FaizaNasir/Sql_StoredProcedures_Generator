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
    
    public partial class GetUnpaidBills_Result
    {
        public int UnpaidBillID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string BillNo { get; set; }
        public Nullable<decimal> BillAmount { get; set; }
        public Nullable<decimal> AmountDue { get; set; }
        public Nullable<decimal> Payment { get; set; }
    }
}
