using System;
using System.Collections.Generic;
using System.Text;

namespace MinVagtPlanDK.Models
{
    public class AllShiftsResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Shift> data { get; set; }
    }
}
