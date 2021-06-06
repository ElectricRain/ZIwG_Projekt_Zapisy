using System.Collections.Generic;

namespace Project_ZIwG.Domain.Data
{
    public class SubjectResponse
    {
        public List<SubjectDto> Subjects { get; set; }
        public string Errors { get; set; }
    }
}
