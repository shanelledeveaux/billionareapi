using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using BillionareApi.Models;

namespace BillionareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly BillionareContext _context;

        public ProductController(BillionareContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IQueryable<Product> GetAllPurchases()
        {
            return _context.Products;
        }
    }
}