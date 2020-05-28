using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElearningWebsite.Entities
{
    public class TypeOfCourse:FullAuditedEntity<long>
    {
        public long CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; }
        public long CourseTypeId { get; set; }
        [ForeignKey(nameof(CourseTypeId))]
        public virtual CourseType CourseType { get; set; }
    }
}
