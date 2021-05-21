using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CortosoUniversity.Models;
using CortosoUniversity.Data;

namespace CortosoUniversity.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly SchoolContext _context;
        public Dictionary<Grade?, int> Grades = new(new List<KeyValuePair<Grade?, int>>()
        {
            new KeyValuePair<Grade?, int>(Grade.TWELVE, 12),
            new KeyValuePair<Grade?, int>(Grade.TEN, 10),
            new KeyValuePair<Grade?, int>(Grade.SEVEN, 7),
            new KeyValuePair<Grade?, int>(Grade.FOUR, 4),
            new KeyValuePair<Grade?, int>(Grade.TWO, 2),
            new KeyValuePair<Grade?, int>(Grade.ZERO, 0),
            new KeyValuePair<Grade?, int>(Grade.NEGATIVE_THREE, -3)
        });

        public DetailsModel(SchoolContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Student = await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.ID == id);

            return Student == null ? NotFound() : Page();
        }
    }
}
