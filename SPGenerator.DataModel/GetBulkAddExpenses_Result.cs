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
    
    public partial class GetBulkAddExpenses_Result
    {
        public int BulkAddExpensesID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> ExpenseAccountID { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<int> PaidThroughID { get; set; }
        public Nullable<int> VendorID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> ProjectID { get; set; }
        public Nullable<bool> Billable { get; set; }
    }
}
