//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chap02.EntityFramework.Obj2_2.DataProvider.EntityConnection1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        public Account()
        {
            this.Customers = new HashSet<Customer>();
        }
    
        public int AccountId { get; set; }
        public string AccountAlias { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
