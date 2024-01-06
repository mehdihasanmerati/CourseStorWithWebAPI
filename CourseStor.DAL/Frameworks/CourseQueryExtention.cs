using CourseStor.Models.Courses.Dto;
using CourseStor.Models.Courses.Entities;
using CourseStor.Models.Courses.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.DAL.Frameworks
{
    public static class CourseQueryExtention
    {
        public static IQueryable<Course> WhereOverCourse(this IQueryable<Course> courses, string title, int id)
        {
            if (!string.IsNullOrEmpty(title))
                courses = courses.Where(c => c.Title.Contains(title));
            if (!string.IsNullOrEmpty(id.ToString()))
                courses = courses.Where(c => c.Id.ToString().Contains(id.ToString()));

            return courses;
        }

        public static async Task <List<CourseQueryResult>> ToQueryCourseAsync(this IQueryable<Course> courses)
        {
            return await courses.Select(c=> new CourseQueryResult
            {
                Id = c.Id,
                Title = c.Title,
            }).ToListAsync();
        }
    }
}
