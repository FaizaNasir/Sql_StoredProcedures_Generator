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
    
    public partial class GetSaleOrders_Result
    {
        public int SalesOrderID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<System.Guid> SalesOrdeNO { get; set; }
        public string ReferenceNo { get; set; }
        public Nullable<System.DateTime> SalesOrderDate { get; set; }
        public Nullable<System.DateTime> ExpectedShipmentDate { get; set; }
        public Nullable<int> PaymentTermID { get; set; }
        public Nullable<int> DeliveryMethodID { get; set; }
        public Nullable<int> SalesPersonID { get; set; }
        public Nullable<int> ItemDetailID { get; set; }
        public string CustomerNotes { get; set; }
        public Nullable<decimal> ShippingCharges { get; set; }
        public Nullable<bool> TermsConditions { get; set; }
        public Nullable<decimal> AgjustmentValue { get; set; }
        public string AdjustmentText { get; set; }
    }
}