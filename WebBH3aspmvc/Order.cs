//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBH3aspmvc
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.Oderdetails = new HashSet<Oderdetail>();
        }
    
        public int oid { get; set; }
        public Nullable<System.DateTime> odate { get; set; }
        public string opname { get; set; }
        public string opphone { get; set; }
        public string oaddress { get; set; }
        public string osaddress { get; set; }
        public Nullable<decimal> oamount { get; set; }
        public Nullable<int> ostatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Oderdetail> Oderdetails { get; set; }
    }
}
