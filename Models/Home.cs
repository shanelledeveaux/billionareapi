using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata.Internal;

namespace BillionareApi.Models
{
    public class Home
    {
        [Key]
        public int HomeId { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public virtual Person Person { get; set; }
        public virtual Location Location { get; set; }
    }
}