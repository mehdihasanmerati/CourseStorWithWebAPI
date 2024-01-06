using CourseStor.Models.Courses.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.DAL.Frameworks
{
    public static class CourseTeacherQueryExtention
    {
        public static IQueryable<CourseTeacher> WhereOverCourseTeacher(this IQueryable<CourseTeacher> courseTeachers, int id)
        {
            if(!string.IsNullOrEmpty(id.ToString()))
                courseTeachers = courseTeachers.Where(c=> c.Id.ToString().Contains(id.ToString()));
            return courseTeachers;
        }

        public static async Task<List<CourseTeacher>> ToCourseTeacherQury(this IQueryable<CourseTeacher> courseTeachers)
        {
             return await courseTeachers.Select(c => new CourseTeacher
             {
                 Id = c.Id,
                 SortOrder = c.SortOrder
            }).ToListAsync();
        }
    }
}
