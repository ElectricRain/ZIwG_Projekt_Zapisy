using Project_ZIwG.Infrastructure.Entities;
using Project_ZIwG.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_ZIwG.Infrastructure.Repositories.InMemoryRepository
{
    public class InMemoryCourseRepository : ICourseRepository
    {
        private List<CourseEntity> _courseEntities = new List<CourseEntity>();

        public void Create(CourseEntity entity)
        {
            _courseEntities.Add(entity);
        }

        public void Delete(Guid entityId)
        {
            _courseEntities.RemoveAll(x => x.Id == entityId);
        }

        public CourseEntity Get(Guid entityId)
        {
            var course = _courseEntities.FirstOrDefault(x => x.Id == entityId);
            return course;
        }

        public IEnumerable<CourseEntity> GetList()
        {
            foreach(var course in _courseEntities)
            {
                yield return course;
            }
        }

        public void Update(CourseEntity entity)
        {
            var course = _courseEntities.FirstOrDefault(x => x.Id == entity.Id);
            course.Description = entity.Description;
            course.CourseName = entity.CourseName;
            course.CourseCode = entity.CourseCode;
        }
    }
}
