//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication3
{
    using System;
    using System.Collections.Generic;
    
    public partial class booking
    {
        public int booking_id { get; set; }
        public int user_id { get; set; }
        public Nullable<int> package_id { get; set; }
        public Nullable<decimal> cost_per_ticket { get; set; }
        public Nullable<decimal> total { get; set; }
        public string payment_mode { get; set; }
        public string payment_status { get; set; }
    
        public virtual package package { get; set; }
        public virtual user user { get; set; }
    }
}