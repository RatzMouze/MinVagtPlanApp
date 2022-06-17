using System;
using System.Collections.Generic;

namespace MinVagtPlanDK.Models
{
    public class Shift
    {
        public string id { get; set; }
        public string schedule_id { get; set; }
        public string user_id { get; set; }
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public string description { get; set; }
        public string absence { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Schedule schedule { get; set; }
        public string groupingString { get; set; }
    }
}
