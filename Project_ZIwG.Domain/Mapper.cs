﻿using Project_ZIwG.Domain.Data;
using Project_ZIwG.Infrastructure.Entities;
using System;
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
                    CourseId = entity.CourseId,
                    CourseName = entity.Course.CourseName,
                    TypeId = entity.TypeId,
                    Type = entity.Type.FullName,
                    Day = Enum.GetName(typeof(DayOfWeek), entity.Day),
                    DayEnum = entity.Day,
                    Parity = Enum.GetName(typeof(Parity), entity.Parity),
                    ParityEnum = entity.Parity,
                    StartHour = entity.StartHour,
                    EndHour = entity.EndHour,
                    TakenBy = entity.UserSubject?.User.Name
                });
            }
            return subjects;
        }

        public static SubjectEntity MapSubjectDto(SubjectDto subjectDto)
        {
            return new SubjectEntity
            {
                Id = subjectDto.SubjectId,
                StartHour = subjectDto.StartHour,
                EndHour = subjectDto.EndHour,
                TypeId = subjectDto.TypeId,
                CourseId = subjectDto.CourseId,
                Day = subjectDto.DayEnum,
                Parity = subjectDto.ParityEnum,
            };
        }
    }
}
