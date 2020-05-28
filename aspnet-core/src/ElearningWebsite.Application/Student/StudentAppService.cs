using Abp.UI;
using ElearningWebsite.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElearningWebsite.Student
{
    public class StudentAppService:AppServiceBase
    {
        public async Task RegisterClass(StudentCourse input)
        {
            try
            {
                await WorkScope.InsertAsync<StudentCourse>(input);
            }catch(Exception ex)
            {
                throw new UserFriendlyException("Có lỗi trong quá trình đăng ký");
            }
        }
    }
}
