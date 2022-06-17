using System;
using System.Collections.Generic;
using System.Text;

namespace MinVagtPlanDK.Models
{
    public class LoginResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public AuthResult data { get; set; }
    }
}
