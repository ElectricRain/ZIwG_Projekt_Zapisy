﻿using Project_ZIwG.Domain.Data;
using Project_ZIwG.Infrastructure.Entities;
using System.Collections.Generic;

namespace Project_ZIwG.Domain
{
    public static class Mapper
    {
        public static List<SubjectDto> MapSubjects(IEnumerable<SubjectEntity> entities)
        {
            var subjects = new List<SubjectDto>();
            foreach (var entity in entities)
            {
                subjects.Add(new SubjectDto { 
                    SubjectId = entity.Id,
                    CourseName = entity.Course.CourseName,
                    Parity = entity.Type.FullName,
                    StartHour = entity.StartHour,
                    EndHour = entity.EndHour,
                    TakenBy = entity.UserSubject?.User.Name
                });
            }
            return subjects;
        }
    }
}