using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CortosoUniversity.Data;
using CortosoUniversity.Models;
using CortosoUniversity.Models.View_Models;

namespace CortosoUniversity.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly SchoolContext _context;

        public IndexModel(SchoolContext context)
        {
            _context = context;
        }

        public IList<CourseViewModel> CoursesVM { get; set; }

        public async Task OnGetAsync()
        {
            CoursesVM = await _context.Courses
                .Select(p => new CourseViewModel
                {
                    ID = p.ID,
                    Title = p.Title,
                    Credits = p.Credits,
                    Department = p.Department.Name
                }).ToListAsync();
        }
    }
}
