﻿using Catalog_Online.Helper;
using Catalog_Online.Models.Dtos;
using Catalog_Online.Models.Entity;
using Catalog_Online.Services;
using System.Collections.Generic;
using System.Linq;

namespace Catalog_Online.ServicesImpl
{
    public class MarkServiceImpl : IMarkService
    {
        RepositoryContext _context;

        public MarkServiceImpl(RepositoryContext context)
        {
            _context = context;
        }

        public Mark AddMark(Mark mark)
        {
            var newMark = _context.Marks.Add(mark);
            _context.SaveChanges();

            return newMark.Entity;
        }

        public List<GetMarkWithSubjectDto> GetMarksByUserId(int id)
        {
            List<Mark> marks = _context.Marks.Where(m => m.UserId == id).ToList();
            List<GetMarkWithSubjectDto> markWithSubjectDtos = new List<GetMarkWithSubjectDto>();
           
            foreach (var mark in marks) 
            {
                var subject = _context.Subjects.FirstOrDefault(s => s.Id == mark.SubjectId);
                GetMarkWithSubjectDto dto = new()
                {
                    SubjectId = mark.SubjectId,
                    UserId = mark.UserId,
                    Value = mark.Value,
                    SubjectName = subject.Name,
                    Semester = subject.Semester,
                    YearOfTeaching = subject.YearOfTeaching,
                    TeacherName = subject.TeacherName,
                };
                markWithSubjectDtos.Add(dto);
            }
            return markWithSubjectDtos;
        }


        public List<Subject> GetSubjectsByCurrentTeacher(User user)
        {
            
            var teacherName = user.FirstName+user.LastName;
            List<Subject> subjects = _context.Subjects.Where(s => s.TeacherName == teacherName).ToList();
            return subjects;
        }

        public List<GetMarksBySubjectDto> GetMarksByCurrentSubjectId(int subjectId)
        {
            List<Mark> marks = _context.Marks.Where(m => m.SubjectId == subjectId).ToList();

            List<GetMarksBySubjectDto> marksBySubjectDtos = new List<GetMarksBySubjectDto>();

            foreach (var mark in marks)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == mark.UserId);
                GetMarksBySubjectDto dto = new()
                {
                    SubjectId = mark.SubjectId,
                    UserId = mark.UserId,
                    Value = mark.Value,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
                marksBySubjectDtos.Add(dto);
            }
            return marksBySubjectDtos;
        }
    }
}
