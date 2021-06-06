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
    }
}
