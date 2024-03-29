﻿using CourseStor.Models.Frameworks;
using CourseStor.Models.Teachers.Entities;

namespace CourseStor.Models.Courses.Entities
{
    public class CourseTeacher: BaseEntity
    {
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public int SortOrder {  get; set; }
    }
}
