using Microsoft.EntityFrameworkCore;
using Project_ZIwG.Domain.Data;
using Project_ZIwG.Infrastructure.Entities;
using Project_ZIwG.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_ZIwG.Domain
{
    public class SubjectsLogic
    {
        private readonly IUserRepository _userRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IUserSubjectRepository _userSubjectRepository;
        private readonly IUserPermissionRepository _userPermissionRepository;

        public SubjectsLogic(IUserRepository userRepository, ISubjectRepository subjectRepository, IUserSubjectRepository userSubjectRepository, IUserPermissionRepository userPermissionRepository)
        {
            _userRepository = userRepository;
            _subjectRepository = subjectRepository;
            _userSubjectRepository = userSubjectRepository;
            _userPermissionRepository = userPermissionRepository;
        }

        public SubjectResponse GetAllSubjects()
        {
            var response = new SubjectResponse();
            try
            {
                var subjects = _subjectRepository.GetList();
                response.Subjects = Mapper.MapSubjects(subjects);
            }
            catch (Exception e)
            {
                response.Errors = e.Message;
            }
            return response;
        }

        public SubjectResponse GetSubjectsForUser(string userId)
        {
            var response = new SubjectResponse();
            try
            {
                var user = _userRepository.Get(new Guid(userId));
                var userPermissions = _userPermissionRepository.GetList().Where(x => x.UserId == user.Id).ToList();
                var subjects = _subjectRepository.GetList().Where(x => userPermissions.Any(p => p.CourseId == x.CourseId && p.TypeId == x.TypeId)).ToList();
                response.Subjects = Mapper.MapSubjects(subjects);
            }
            catch (Exception e)
            {
                response.Errors = e.Message;
            }
            return response;
        }

        public SubjectResponse GetSubjectsPossibleForUser(string userId)
        {
            var response = new SubjectResponse();
            try
            {
                var user = _userRepository.Get(new Guid(userId));
                var userPermissions = _userPermissionRepository.GetList().Where(x => x.UserId == user.Id).ToList();
                var subjects = _subjectRepository.GetList().Where(x => userPermissions.Any(p => p.CourseId == x.CourseId && p.TypeId == x.TypeId)).ToList();
                var test = _userSubjectRepository.GetList();
                var userIdGUID = new Guid(userId);
                var takenSubjects = _userSubjectRepository.GetList().Where(x => x.UserId != userIdGUID).ToList();
                var possibleSubjects = subjects.Where(x => takenSubjects.Any(t => t.SubjectId != x.Id)).ToList();
                response.Subjects = Mapper.MapSubjects(possibleSubjects);
            }
            catch (Exception e)
            {
                response.Errors = e.Message;
            }
            return response;
        }

        public SubjectResponse SignOutFromSubject(string userId, string subjectId)
        {
            var response = new SubjectResponse();
            var takenSubject = _userSubjectRepository.GetList().Where(x => x.SubjectId == new Guid(subjectId) && x.UserId == new Guid(userId)).ToList();
            if (takenSubject.Count > 0)
            {
                var subject = _subjectRepository.Get(new Guid(subjectId));
                var user = _userRepository.Get(new Guid(userId));
                _userSubjectRepository.Delete(takenSubject.FirstOrDefault().Id);
            }
            return response;
        }

        public SubjectResponse SignForSubject(string userId, string subjectId)
        {
            var response = new SubjectResponse();
            var takenSubject = _userSubjectRepository.GetList().Where(x => x.SubjectId == new Guid(subjectId)).ToList();
            if(takenSubject.Count == 0)
            {
                var subject = _subjectRepository.Get(new Guid(subjectId));
                var user = _userRepository.Get(new Guid(userId));
                var userPermissions = _userPermissionRepository.GetList().Where(x => (x.UserId == user.Id && x.CourseId == subject.CourseId && x.TypeId == subject.TypeId)).ToList();
                if(userPermissions.Count > 0)
                {
                    _userSubjectRepository.Create(new UserSubjectEntity
                    {
                        Id = Guid.NewGuid(),
                        SubjectId = subject.Id,
                        UserId = user.Id
                    });
                }
            }
            return response;
        }

        public SubjectResponse GetSubjectsTakenByUser(string userId)
        {
            var response = new SubjectResponse();
            try
            {
                var userIdGUID = new Guid(userId);
                var takenSubjects = _userSubjectRepository.GetList().Where(x => x.UserId == userIdGUID).ToList();
                var possibleSubjects = _subjectRepository.GetList().Where(x => takenSubjects.Any(t => t.SubjectId == x.Id)).ToList();
                response.Subjects = Mapper.MapSubjects(possibleSubjects);
            }
            catch (Exception e)
            {
                response.Errors = e.Message;
            }
            return response;
        }
    }
}
