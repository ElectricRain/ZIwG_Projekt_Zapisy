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

        public DateTime StartHour { get; set; }

        public DateTime EndHour { get; set; }

        public Parity Parity { get; set; }

        public CourseEntity Course { get; set; }

        public TypeEntity Type { get; set; }

        public List<UserSubjectEntity> UserSubjects { get; set; }
    }
}
