using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinVagtPlanDK.Models
{
    public class AuthObj
    {
        [PrimaryKey]
        public string AuthKey { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime KeyEndDate { get; set; }
    }
}
