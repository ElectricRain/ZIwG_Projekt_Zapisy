using Project_ZIwG.Infrastructure.Entities;
using Project_ZIwG.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_ZIwG.Infrastructure.Repositories.InMemoryRepository
{
    public class InMemorySubjectRepository : ISubjectRepository
    {
        private List<SubjectEntity> _subjectEntities = new List<SubjectEntity>(); 
        public void Create(SubjectEntity entity)
        {
            _subjectEntities.Add(entity);
        }

        public void Delete(Guid entityId)
        {
            _subjectEntities.RemoveAll(x => x.Id == entityId);
        }

        public SubjectEntity Get(Guid entityId)
        {
            var subject = _subjectEntities.FirstOrDefault(x => x.Id == entityId);
            return subject;
        }

        public IEnumerable<SubjectEntity> GetList()
        {
            foreach(var subject in _subjectEntities)
            {
                yield return subject;
            }
        }

        public void Update(SubjectEntity entity)
        {
            var subject = _subjectEntities.FirstOrDefault(x => x.Id == entity.Id);
            subject.TypeId = entity.TypeId;
            subject.StartHour = entity.StartHour;
            subject.EndHour = entity.EndHour;
            subject.Day = entity.Day;
            subject.CourseId = entity.CourseId;
            subject.Parity = entity.Parity;
        }
    }
}
