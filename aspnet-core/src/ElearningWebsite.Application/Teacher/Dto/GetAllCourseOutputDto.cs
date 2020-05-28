using Abp.Domain.Entities;
using ElearningWebsite.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningWebsite.Teacher.Dto
{
    public class GetAllCourseOutputDto:Entity<long>
    {
        public string? Tilte { get; set; }
        public string? Creator { get; set; }
        public DateTime? DateCreator { get; set; }
        public DateTime? LastModify { get; set; }
        public string? Description { get; set; }
        //public List<string> TypeOfCourses { get; set; }
        //public long TotalCount { get; set; }
    }
    public class GetAllCourseInput:GridParamFake
    {
        public long? UserID { get; set; }
        public string NameOfCourse { get; set; }
        
    }
    public class GridParamFake
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
