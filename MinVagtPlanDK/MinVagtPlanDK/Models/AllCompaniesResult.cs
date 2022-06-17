using System;
using System.Collections.Generic;
using System.Text;

namespace MinVagtPlanDK.Models
{
    public class AllCompaniesResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Company> data { get; set; }
    }
}
