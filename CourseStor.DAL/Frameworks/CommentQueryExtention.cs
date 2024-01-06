using CourseStor.Models.Comments.Dto;
using CourseStor.Models.Comments.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.DAL.Frameworks
{
    public static class CommentQueryExtention
    {
        public static IQueryable<Comment> WhereOverComment(this IQueryable<Comment> comments, int id)
        {
            if(!string.IsNullOrEmpty(id.ToString()))
                comments = comments.Where(c=> c.Id.ToString().Contains(id.ToString()));
            return comments;
        }

        public static async Task<List<CommentQueryResult>> ToQueryCommentAsync(this IQueryable<Comment> comments)
        {
            return await comments.Select(c=> new CommentQueryResult
            {
                Id = c.Id,
                CommentBy = c.CommentBy,
                Comments = c.Comments,
                StarRate = c.StarRate,
            }).ToListAsync();
        }
    }
}
