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
    
    public partial class GetEstimates_Result
    {
        public Nullable<int> CustomerID { get; set; }
        public int EstimateID { get; set; }
        public Nullable<System.Guid> EstimateNo { get; set; }
        public string ReferenceNo { get; set; }
        public Nullable<System.DateTime> EstimateDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<int> SalesPersonID { get; set; }
        public Nullable<int> ProjectID { get; set; }
        public string Subject { get; set; }
        public Nullable<int> ItemDetailID { get; set; }
        public string CustomerNotes { get; set; }
        public Nullable<bool> RetainerInvoice { get; set; }
        public Nullable<decimal> ShippingCharges { get; set; }
        public Nullable<bool> TermsConditions { get; set; }
        public Nullable<decimal> AdjustmentValue { get; set; }
        public string AdjustmentText { get; set; }
    }
}