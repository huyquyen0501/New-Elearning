using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
using ElearningWebsite.Authorization.Roles;
using ElearningWebsite.Entities;
using ElearningWebsite.Teacher.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningWebsite.Teacher
{
    public class TeacherAppService:AppServiceBase
    {
        public  bool CheckPerMissionCourse(long userId, long CourseId)
        {
            
            var admin = WorkScope.GetRepo<UserRole>().GetAllIncluding(s => s.RoleId).Where(s => s.UserId == userId).Any(s => s.RoleId == 1);
            var teacher = WorkScope.GetRepo<UserRole>().GetAllIncluding(s => s.RoleId).Where(s => s.UserId == userId).Any(s => s.RoleId == 2);
            var b = WorkScope.GetAll<Course>().Where(s => s.CreatorUserId == userId).Any();
            if (admin==true ||(teacher == b == true))
            {
                return true;
            }
            else
            {
                throw new UserFriendlyException("Bạn không có quyền thực hiện chức năng này");
                //return false;
            }
        }
        public bool IsTeacher()
        {
            var a = AbpSession.UserId;
            var teacher = WorkScope.GetRepo<UserRole>().GetAllIncluding(s => s.RoleId).Where(s => s.UserId == a).Any(s => s.RoleId == 2);
            if (teacher == true)
            {
                return true;
            }
            else
            {
                throw new UserFriendlyException("Bạn không phải giáo viên, liên hệ admin để được hỗ trợ");
            }
        }
        

        public async Task<PagedResultDto<GetAllCourseOutputDto>> GetAllCoursePaging(GetAllCourseInput input)
        {
            using (CurrentUnitOfWork.DisableFilter(AbpDataFilters.SoftDelete))
            {
                
             
                var a = WorkScope.GetAll<Course>().WhereIf(!input.NameOfCourse.IsNullOrWhiteSpace(),s => s.Title.Contains(input.NameOfCourse))
                    .Where(s=>s.IsDeleted==false)
                    .WhereIf(input.UserID.HasValue,s=>s.UserId==input.UserID)
                        .Select(s => new GetAllCourseOutputDto
                        {
                            Id=s.Id,
                            Creator = s.Creator.FullName,
                            DateCreator = s.CreationTime,
                            LastModify = s.LastModificationTime,
                            Tilte = s.Title,
                            Description = s.Details,
                            //TypeOfCourses=d.CourseType.Deltail.ToList()
                        });
                var TotalCount = await a.CountAsync();
                var result = await a.Skip(input.PageNumber - 1).Take(input.PageSize).ToListAsync();
                return new PagedResultDto<GetAllCourseOutputDto>(TotalCount, result);

            }
        }
       /* public async Task<PagedResultDto<GetAllCourseOutputDto>> GetAllCourseOfTeacher(GetAllCourseInput input)
        {
            var a = WorkScope.GetAll<Course>().WhereIf(!input.NameOfCourse.IsNullOrWhiteSpace(), s => s.Title.Contains(input.NameOfCourse))
                   .Where(s => s.IsDeleted == false)
                   .WhereIf(input.UserID.HasValue, s => s.UserId == input.UserID)
                       .Select(s => new GetAllCourseOutputDto
                       {
                           Id = s.Id,
                           Creator = s.Creator.FullName,
                           DateCreator = s.CreationTime,
                           LastModify = s.LastModificationTime,
                           Tilte = s.Title,
                           Description = s.Details,
                            //TypeOfCourses=d.CourseType.Deltail.ToList()
                        });
            var TotalCount = await a.CountAsync();
            var result = await a.Skip(input.PageNumber - 1).Take(input.PageSize).ToListAsync();
            return new PagedResultDto<GetAllCourseOutputDto>(TotalCount, result);
        }*/
        public async Task<long> CreateCourse(CreateCourseInput input)
        {
            using (CurrentUnitOfWork.DisableFilter(AbpDataFilters.SoftDelete))
            {
                if(IsTeacher() == true){
                    if (WorkScope.GetAll<Course>().Where(s => s.IsDeleted == false && (s.Title == input.Title || s.Code == input.Code)).Any())
                    {
                        throw new UserFriendlyException("Đã tồn tại tên hoặc code khóa học");
                    }
                    else
                    {
                        var a = input.MapTo<Course>();
                        a.UserId = AbpSession.UserId ?? 0;
                        var id = await WorkScope.InsertAndGetIdAsync<Course>(a);
                        return id;
                    }
                }else
                { throw new UserFriendlyException("Bạn không phải giáo viên, liên hệ admin để được hỗ trợ"); }
            }
        }
        public async Task UpdateCourse(UpdateCoures input)
        {
            using (CurrentUnitOfWork.DisableFilter(AbpDataFilters.SoftDelete))
            {
                CheckPerMissionCourse(AbpSession.UserId??0, input.Id);
                if (WorkScope.GetAll<Course>().Where(s => s.IsDeleted == false && (s.Title == input.Title || s.Code == input.Code)).Any())
                {
                    throw new UserFriendlyException("Đã tồn tại tên hoặc code khóa học");
                }
                else
                {
                    var temped = WorkScope.GetAll<Course>().Where(s => s.Id == input.Id).Select(s => s).FirstOrDefault();
                    temped.Title = input.Title;
                    temped.Details = input.Detail;
                    temped.Code = input.Code;
                    temped.LastModifierUserId = AbpSession.UserId;
                    await WorkScope.UpdateAsync<Course>(temped);
                }
            }
        } 
        public async Task DeleteCourse(long CourseId)
        {
            if (CheckPerMissionCourse(AbpSession.UserId ?? 0, CourseId))
            {
                var a = WorkScope.GetAll<Course>().Where(s => s.Id == CourseId).Select(s => s).FirstOrDefault();
                var b = WorkScope.GetAll<Lesson>().Where(s => s.CourseId == CourseId).Select(s => s);
                WorkScope.SoftDeleteAsync<Course>(a);
                foreach (var i in b)
                {
                    WorkScope.SoftDelete<Lesson>(i);
                }
            }
            else
            {
                throw new UserFriendlyException("Bạn không có quyền thực hiện chức năng này");
            }
            
        }    
        public async Task CreateLesson(CreateLesson Input)
        {
            using (CurrentUnitOfWork.DisableFilter(AbpDataFilters.SoftDelete))
            {
                if (CheckPerMissionCourse(AbpSession.UserId ?? 0, Input.Id))
                {
                    if (WorkScope.GetAll<Lesson>().Where(s => s.IsDeleted == false).Any(s => Input.CourseId == s.CourseId && s.Tilte.Contains(Input.Tilte)))
                    {
                        throw new UserFriendlyException("Khóa học đã tồn tại bài học này");
                    }
                    else
                    {
                        var a = Input.MapTo<Lesson>();
                        a.CreatorUserId = AbpSession.UserId ?? 0;
                        var Id = await WorkScope.InsertAndGetIdAsync<Lesson>(a);
                    }
                }
                else{
                    throw new UserFriendlyException("Bạn không có quyền");
                }
            }    
        }
        public async Task UpdateLesson(CreateLesson Input)
        {
            using (CurrentUnitOfWork.DisableFilter(AbpDataFilters.SoftDelete))
            {
                if (CheckPerMissionCourse(AbpSession.UserId ?? 0, Input.Id))
                {
                    if (WorkScope.GetAll<Lesson>().Where(s => s.IsDeleted == false).Any(s => Input.CourseId == s.CourseId && s.Tilte.Contains(Input.Tilte)))
                    {
                        throw new UserFriendlyException("Khóa học đã tồn tại bài học này");
                    }
                    else
                    {
                        var a = Input.MapTo<Lesson>();
                        a.CreatorUserId = AbpSession.UserId ?? 0;
                        await WorkScope.UpdateAsync<Lesson>(a);
                        //throw new UserFriendlyException("Thành công");
                    }
                }
                else
                {
                    throw new UserFriendlyException("Bạn không có quyền");
                }
            }
        }
        public async Task DeleteLesson(long LessonId)
        {
            using (CurrentUnitOfWork.DisableFilter(AbpDataFilters.SoftDelete))
            {

                var a = WorkScope.GetAll<Lesson>().Where(s => s.Id == LessonId).Select(s => s).FirstOrDefault();
                WorkScope.SoftDeleteAsync<Lesson>(a);
            }
        }
        public async Task<PagedResultDto<CommonDto>> GetAllLessonOfCourse(int PageNumBer,int PageSize,long CourseId)
        {
            var a=  WorkScope.GetAll<Lesson>()
                .Where(s => s.IsDeleted == false)
                .Where(s => s.CourseId == CourseId).Select(s => new CommonDto { Id=s.Id,Title=s.Tilte});
            var TotalCount = await a.CountAsync();
            var result = a.Skip((PageNumBer - 1) * PageSize).Take(PageSize).ToList();
            return new PagedResultDto<CommonDto>(TotalCount, result);

        }
        public async Task<GetAllLessonDto> ViewLesson(long LessonId)
        {
            return await WorkScope.GetAll<Lesson>()
               .Where(s => s.IsDeleted == false)
               .Where(s => s.Id == LessonId).Select(s =>new GetAllLessonDto { Id=s.Id,
               Title=s.Tilte,
               Detail=s.Detail
               }).FirstOrDefaultAsync();
        }
    }
}
