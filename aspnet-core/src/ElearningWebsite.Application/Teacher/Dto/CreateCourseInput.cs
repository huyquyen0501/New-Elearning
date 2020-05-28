using Abp.AutoMapper;
using Abp.Domain.Entities;
using ElearningWebsite.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningWebsite.Teacher.Dto
{
    [AutoMapTo(typeof(Course))]
    public class CreateCourseInput
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Code { get; set; }
    }
    public class UpdateCoures : Entity<long>
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Code { get; set; }
    }
}
