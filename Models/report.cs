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
    
    public partial class report
    {
        public int f_id { get; set; }
        public int u_id_reported { get; set; }
        public int u_id_reportedby { get; set; }
        public string type { get; set; }
        public int id { get; set; }
        public string content { get; set; }
        public System.DateTime time_sent { get; set; }
        public int mod_id { get; set; }
        public int reply_id { get; set; }
        public int read { get; set; }
    
        public virtual user user { get; set; }
        public virtual user user1 { get; set; }
    }
}
