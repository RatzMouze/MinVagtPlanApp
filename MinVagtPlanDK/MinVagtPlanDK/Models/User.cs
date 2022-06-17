using System;
using System.Collections.Generic;
using System.Text;

namespace MinVagtPlanDK.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string email_verified_at { get; set; }
        public string phone { get; set; }
        public bool is_admin { get; set; }
        public bool activated { get; set; }
        public bool notification_mails_enable { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; } 
    }
}
