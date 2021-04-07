using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace homework9.Models
{
    public partial class Applicants
    {
        public Applicants()
        {
            Requests = new HashSet<Requests>();
        }

        public int Id { get; set; } 
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Cedula { get; set; }
        public DateTime BirthDate { get; set; }
        public int? BloodId { get; set; }
        public int? RequestId { get; set; }
        public bool Covid19Flag { get; set; }
        public string Phone { get; set; }

        public virtual Bloods Blood { get; set; }
        public virtual Requests Request { get; set; }
        public virtual ICollection<Requests> Requests { get; set; }
    }
}
