//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class thread
    {
        public int t_id { get; set; }
        public int a_id { get; set; }
        public string topic { get; set; }
        public string active { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int approve { get; set; }
        public int disapprove { get; set; }
        public System.DateTime created { get; set; }
        public string identifier { get; set; }
        public int attributes { get; set; }
    }
}
