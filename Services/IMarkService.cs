﻿using Catalog_Online.Models.Dtos;
using Catalog_Online.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Catalog_Online.Services
{
    public interface IMarkService
    {
        public Mark AddMark(Mark mark);

        public List<GetMarkWithSubjectDto> GetMarksByUserId(int id);

        public List<Subject> GetSubjectsByCurrentTeacher(User user);

        public List<GetMarksBySubjectDto> GetMarksByCurrentSubjectId(int subjectId);
    }
}
