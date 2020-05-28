using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningWebsite.Entities
{
    public class CourseType:FullAuditedEntity<long>
    {
        public string Deltail { get; set; }
    }
}
