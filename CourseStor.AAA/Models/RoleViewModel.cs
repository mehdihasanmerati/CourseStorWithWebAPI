using System.ComponentModel.DataAnnotations;

namespace CourseStor.AAA.Models
{
    public class RoleViewModel
    {
        public string? Id { get; set; }
        [Required,StringLength(10,MinimumLength =2)]
        public string Name { get; set; }
    }
}
