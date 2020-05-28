using Abp.AutoMapper;
using Abp.Domain.Entities;
using ElearningWebsite.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningWebsite.Teacher.Dto
{
    [AutoMapTo(typeof(Lesson))]
    public class CreateLesson:Entity<long>
    {
        public string Tilte { get; set; }
        public string Detail { get; set; }
        public long CourseId { get; set; }
    }
    public class UpdateLesson:Entity<long>
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Code { get; set; }
    }
}
