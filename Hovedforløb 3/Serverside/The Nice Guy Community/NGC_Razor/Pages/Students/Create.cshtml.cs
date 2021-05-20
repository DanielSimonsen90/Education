using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NGC_Razor.Models;
using NGC_Razor.Models.View_Models;

namespace NGC_Razor.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly SchoolContext _context;

        public CreateModel(SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StudentVM StudentVM { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //Student empty = new();
            //bool updated = await TryUpdateModelAsync(empty, "student", 
            //    s => s.FirstMidName, 
            //    s => s.LastName, 
            //    s => s.EnrollmentDate
            //);

            if (!ModelState.IsValid /*|| !updated*/)
                return Page();

            var entry = _context.Add(new Student());
            entry.CurrentValues.SetValues(StudentVM);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            //https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/crud?view=aspnetcore-5.0#overposting
        }
    }
}
