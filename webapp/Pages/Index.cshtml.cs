using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using webapp.Data;

namespace webapp.Pages
{
    public class IndexModel : PageModel
    {
        readonly ILogger<IndexModel> _logger;
        readonly AppDbContext _dbContext;

        public IndexModel(ILogger<IndexModel> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> OnGet()
        {
            var people = await _dbContext.People.ToArrayAsync();
            People = people;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var newPerson = new Person()
            {
                FirstName = AddPerson.FirstName,
                LastName = AddPerson.LastName,
                City = AddPerson.City,
                Street = AddPerson.Street
            };
            _dbContext.People.Add(newPerson);
            var saveCount = await _dbContext.SaveChangesAsync();
            if (saveCount == 1)
            {
                return RedirectToPage();
            }

            return Page();
        }
        
        [BindProperty]
        public AddPersonModel AddPerson { get; set; }
        
        public IEnumerable<Person> People { get; private set; }
    }

    public class AddPersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
    }
}
