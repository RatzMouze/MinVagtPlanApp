using System;
using System.Collections.Generic;
using System.Text;

namespace MinVagtPlanDK.Models
{
    public class SingleShiftResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public Shift data { get; set; }
    }
}
