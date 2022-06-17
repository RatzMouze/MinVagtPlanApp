using System;
using System.Collections.Generic;
using System.Text;

namespace MinVagtPlanDK.Models
{
    public class Schedule
    {
        public string id { get; set; }
        public string company_id { get; set; }
        public string name { get; set; }
        public string colorHex  { get; set; }
        public string active { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Company company { get; set; }

    }
}
