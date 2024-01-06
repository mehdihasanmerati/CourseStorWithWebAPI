using CourseStor.Models.Frameworks;
using CourseStor.Models.Tags.Dto;
using CourseStor.Models.Tags.Entities;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.Models.Tags.Quries
{
    public class FilterByName: IRequest<ApplicationServiceResponse<List<TagQueryResult>>>
    {
        public int Id { get; set; }
        public string? TagName { get; set; }
    }
}

