using Abp.Domain.Entities.Auditing;
using ElearningWebsite.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElearningWebsite.Entities
{
    public class StudentCourse:FullAuditedEntity<long>
    {
        public long UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public virtual User User { get; set; }
        public long CourseID { get; set; }
        [ForeignKey(nameof(CourseID))]
        public virtual Course Course { get; set; }
    }
}
