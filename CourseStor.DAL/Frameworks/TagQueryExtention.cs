using CourseStor.Models.Tags.Dto;
using CourseStor.Models.Tags.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.DAL.Frameworks
{
    public static class TagQueryExtention
    {
        public static IQueryable<Tag> WhereOver(this IQueryable<Tag> tags, string tagName, int id)
        {
            if(!string.IsNullOrEmpty(tagName))
                tags = tags.Where(c=> c.TagName.Contains(tagName));
            if (!string.IsNullOrEmpty(id.ToString()))
                tags = tags.Where(c => c.Id.ToString().Contains(id.ToString()));
            return tags;
        }

        public static List<TagQueryResult> ToQueryResult(this IQueryable<Tag> tags)
        {
            return tags.Select(c => new TagQueryResult
            {
                Id = c.Id,
                TagName = c.TagName,
            }).ToList();
        }
        public static async Task<List<TagQueryResult>> ToQueryResultAsync(this IQueryable<Tag> tags)
        {
            return await tags.Select(c => new TagQueryResult
            {
                Id = c.Id,
                TagName = c.TagName,
            }).ToListAsync();
        }

    }
}
