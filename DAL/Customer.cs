//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public int MembershipTypeId { get; set; }
        public string DocumentLink { get; set; }
        public System.DateTime? MembershipStartTime { get; set; }
        public System.DateTime? MembershipEndTime { get; set; }
        public bool MembershipStatus { get; set; }
        public string CustomerType { get; set; }
    
        public virtual MembershipType MembershipType { get; set; }
        public virtual User User { get; set; }
    }
}
