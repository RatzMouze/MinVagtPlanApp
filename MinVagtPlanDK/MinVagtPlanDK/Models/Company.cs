using System;
using System.Collections.Generic;
using System.Text;

namespace MinVagtPlanDK.Models
{
    public class Company
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public string zipcode { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Pivot pivot { get; set; }
    }
}
