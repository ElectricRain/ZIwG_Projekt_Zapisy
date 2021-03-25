using System;

namespace Project_ZIwG.Infrastructure.Entities
{
    public class SubjectEntity
    {

        public Guid Id { get; set; }

        public string Type { get; set; }

        public DayOfWeek Day { get; set; }

        public int Hour { get; set; } // to change 

        public Parity Parity { get; set; }

    }
}
