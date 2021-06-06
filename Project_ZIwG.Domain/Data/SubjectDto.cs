using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ZIwG.Domain.Data
{
    public class SubjectDto
    {
        public Guid SubjectId { get; set; }
        public string CourseName { get; set; }
        public string Parity { get; set; }
        public TimeSpan StartHour { get; set; }
        public TimeSpan EndHour { get; set; }
        public string TakenBy { get; set; }
    }
}
