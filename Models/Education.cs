using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata.Internal;

namespace BillionareApi.Models
{
    public class Education
    {
        [Key]
        public int EducationId { get; set; }
        public string Institution { get; set; }
        public string FieldOfStudy { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public int PersonId { get; set; }
        public virtual Billionare Billionare { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}