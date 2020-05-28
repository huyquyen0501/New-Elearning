using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningWebsite.Teacher.Dto
{
    public class CommonDto:Entity<long>
    {
        public string Title { get; set; }
    }
}
