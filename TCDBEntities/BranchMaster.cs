//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TCDBEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class BranchMaster
    {
        public BranchMaster()
        {
            this.Quotation_Details = new HashSet<Quotation_Details>();
        }
    
        public int Branch_ID { get; set; }
        public string Branch_Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    
        public virtual ICollection<Quotation_Details> Quotation_Details { get; set; }
    }
}
