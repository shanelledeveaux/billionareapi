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
        public IQueryable<Billionare> GetAllBillionares()
        {
            var people = _context.Billionare
                .Include(a => a.BillionareIncomeSources)
                .Include(a => a.BillionareAccomplishments)
                .Include(a => a.Education);

            return people;
        }

        // [HttpGet]
        // public IQueryable<Product> GetAllPurchases()
        // {
        //     return _context.Products;
        // }
    }
}

