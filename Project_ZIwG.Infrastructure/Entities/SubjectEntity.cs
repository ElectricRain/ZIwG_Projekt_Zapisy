using System;

namespace Project_ZIwG.Infrastructure.Entities
{
    public class SubjectEntity
    {

        public Guid Id { get; set; }

        public Guid CourseId { get; set; }

        public Guid TypeId { get; set; }

        public DayOfWeek Day { get; set; }

        public DateTime StartHour { get; set; } 

        public DateTime EndHour { get; set; }

        public Parity Parity { get; set; }



    }
}
