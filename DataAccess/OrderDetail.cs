//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderDetail
    {
        public short OrderDetailID { get; set; }
        public short IdOrder { get; set; }
        public string SeedsSource { get; set; }
        public Nullable<byte> Germination { get; set; }
        public string Description { get; set; }
    
        public virtual Order Order { get; set; }
    }
}
