using System;
using Project_ZIwG.Infrastructure.Entities;

namespace Project_ZIwG.Domain.Data
{
    public class SubjectDto
    {
        public Guid SubjectId { get; set; }
        public Guid CourseId { get; set; }
        public Guid TypeId { get; set; }
        public string CourseName { get; set; }
        public string Type { get; set; }
        public string Day { get; set; }
        public DayOfWeek DayEnum { get; set; }
        public string Parity { get; set; }
        public Parity ParityEnum { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
        public string TakenBy { get; set; }
    }
}
