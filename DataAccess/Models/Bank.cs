using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Bank
    {
        public Bank()
        {
            Rates = new HashSet<Rate>();
        }

        public int Id { get; set; }
        public string BankName { get; set; }
        public string BankUrl { get; set; }

        public virtual ICollection<Rate> Rates { get; set; }
    }
}
