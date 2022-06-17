using System;
using System.Collections.Generic;
using System.Text;

namespace MinVagtPlanDK.Models
{
    public class SingleCompanyResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public Company data { get; set; }
    }
}
