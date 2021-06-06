using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_ZIwG.Infrastructure.Entities
{
    public class SubjectEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid CourseId { get; set; }

        public Guid TypeId { get; set; }

        public DayOfWeek Day { get; set; }

        public TimeSpan StartHour { get; set; }

        public TimeSpan EndHour { get; set; }

        public Parity Parity { get; set; }

        public virtual CourseEntity Course { get; set; }

        public virtual TypeEntity Type { get; set; }

        public virtual UserSubjectEntity UserSubject { get; set; }
    }
}
