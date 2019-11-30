using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using BillionareApi.Models;

namespace BillionareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillionareController : ControllerBase
    {
        private readonly BillionareContext _context;

        public BillionareController(BillionareContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IQueryable<Person> GetAll()
        {
            var people = _context.People
                .Include(a => a.Pronoun)
                .Include(a => a.Accomplishments)
                .Include(a => a.Education)
                    .ThenInclude(b => b.Location)
                .Include(a => a.OtherAssociations);

            return people;

        }
    }
}

