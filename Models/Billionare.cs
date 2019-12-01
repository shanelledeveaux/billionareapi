using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata.Internal;

namespace BillionareApi.Models
{
    public class Billionare
    {
        [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate{ get; set; }
        public string Description { get; set; }
        public int NetWorth { get; set; }
        public virtual Pronoun Pronoun { get; set; }
        public ICollection<BillionareAccomplishment> BillionareAccomplishments { get; set; }
        public ICollection<BillionareIncomeSource> BillionareIncomeSources { get; set; }
        public ICollection<Education> Education { get; set; }
    }
}