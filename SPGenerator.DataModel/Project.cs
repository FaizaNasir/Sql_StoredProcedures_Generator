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
    
    public partial class Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> BillingMethodID { get; set; }
        public Nullable<decimal> CostBudget_ { get; set; }
        public Nullable<decimal> RevenueBudget { get; set; }
        public Nullable<int> HoursBudgetTypeID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> TaskID { get; set; }
    }
}
