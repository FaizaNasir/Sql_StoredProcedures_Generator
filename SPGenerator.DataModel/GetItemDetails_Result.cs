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
    
    public partial class GetItemDetails_Result
    {
        public int ItemDetailID { get; set; }
        public string ItemDetails { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<int> TaxID { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> QuantityAvailable { get; set; }
        public Nullable<decimal> NewQuantityInHand { get; set; }
        public Nullable<decimal> QuantityAdjusted { get; set; }
        public Nullable<int> CustomerID { get; set; }
    }
}
