using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningWebsite.Teacher.Dto
{
    public class GetAllLessonDto:Entity<long>
    {
        public string Title { get; set; }
        public string Detail { get; set; }
    }
}
