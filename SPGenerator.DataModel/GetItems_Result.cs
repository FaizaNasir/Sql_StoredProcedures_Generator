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
    
    public partial class GetItems_Result
    {
        public int ItemID { get; set; }
        public Nullable<int> TypeID { get; set; }
        public Nullable<int> Name { get; set; }
        public Nullable<int> UnitID { get; set; }
        public Nullable<bool> SalesInformation { get; set; }
        public Nullable<decimal> SellingPrice { get; set; }
        public Nullable<int> SellingAccountID { get; set; }
        public string SellingDescription { get; set; }
        public Nullable<int> TaxID { get; set; }
        public Nullable<bool> PurchaseInformation { get; set; }
        public Nullable<decimal> CostPrice { get; set; }
        public Nullable<int> PurchaseAccountID { get; set; }
        public string PuchaseDescription { get; set; }
        public Nullable<bool> TrackInventory { get; set; }
    }
}