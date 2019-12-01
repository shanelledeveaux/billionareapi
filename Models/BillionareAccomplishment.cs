using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata.Internal;

namespace BillionareApi.Models
{
    public class BillionareAccomplishment
    {
        [Key]
        public int AccomplishmentId { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public virtual Billionare Billionare { get; set; }
    }
}