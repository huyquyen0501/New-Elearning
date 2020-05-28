using Abp.Dependency;
using Abp.Domain.Services;
using ElearningWebsite.IoC;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningWebsite.DomainServices
{
    public class BaseDomainService:IDomainService
    {
        public IWorkScope WorkScope { get; set; }
        public BaseDomainService()
        {
            this.WorkScope = IocManager.Instance.Resolve<IWorkScope>();
        }
    }
}
