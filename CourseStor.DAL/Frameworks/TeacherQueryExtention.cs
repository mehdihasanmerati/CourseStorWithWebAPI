using CourseStor.Models.Teachers.Dto;
using CourseStor.Models.Teachers.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.DAL.Frameworks
{
    public static class TeacherQueryExtention
    {
        public static IQueryable<Teacher> WhereOverTeacher(this IQueryable<Teacher> teachers, string id)
        {
            if (!string.IsNullOrEmpty(id.ToString()))
                teachers = teachers.Where(c=> c.Id.ToString().Contains(id));
            return teachers;
        }

        public static async Task<List<TeacherQueryResult>> ToQueryTeacherAsync(this IQueryable<Teacher> teachers)
        {
            return await teachers.Select(c=> new TeacherQueryResult
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
            }).ToListAsync();
        }

    }
}
