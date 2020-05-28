using Abp.Domain.Entities.Auditing;
using ElearningWebsite.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElearningWebsite.Entities
{
    public class Course: FullAuditedEntity<long>
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public long UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        public string Code { get; set; }
        [ForeignKey(nameof(CreatorUserId))]
        public virtual User Creator { get; set; }
    }
}
