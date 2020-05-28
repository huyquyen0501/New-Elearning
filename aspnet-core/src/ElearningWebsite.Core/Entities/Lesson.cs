using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElearningWebsite.Entities
{
    public class Lesson:FullAuditedEntity<long>
    {
        public string Tilte { get; set; }
        public string Detail { get; set; }
        public long CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; }
    }
}
