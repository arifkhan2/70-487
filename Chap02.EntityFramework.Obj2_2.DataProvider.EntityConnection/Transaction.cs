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
    
    public partial class Transaction
    {
        public Transaction()
        {
            this.TransactionDetails = new HashSet<TransactionDetail>();
        }
    
        public int TransactionId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public Nullable<decimal> Amount { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual ICollection<TransactionDetail> TransactionDetails { get; set; }
    }
}
