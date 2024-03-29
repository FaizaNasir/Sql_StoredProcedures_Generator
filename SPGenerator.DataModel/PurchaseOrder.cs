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
    
    public partial class PurchaseOrder
    {
        public int PurchaseOrderID { get; set; }
        public Nullable<int> VendorID { get; set; }
        public Nullable<int> DeliverToID { get; set; }
        public Nullable<System.Guid> PurchaseOrderNo { get; set; }
        public string ReferenceNo { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> ExpectedDeliveryDate { get; set; }
        public Nullable<int> PaymentTermID { get; set; }
        public string ShipmentPreference { get; set; }
        public Nullable<int> ItemDetailID { get; set; }
        public string CustomerNotes { get; set; }
        public string AdjustmentText { get; set; }
        public Nullable<bool> TermsConditions { get; set; }
        public Nullable<decimal> AdjustmentValue { get; set; }
        public Nullable<decimal> ShippingCharges { get; set; }
    }
}
