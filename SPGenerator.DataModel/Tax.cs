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
    
    public partial class Tax
    {
        public int TaxID { get; set; }
        public string TaxName { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<bool> CompoundTax { get; set; }
    }
}
