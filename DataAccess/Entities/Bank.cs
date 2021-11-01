using System.Collections.Generic;

namespace DataAccess.Entities
{
    class Bank
    {
        public int ID { get; set; }
        public string BankName { get; set; }
        public string BankURL { get; set; }

        public ICollection<Rate> Rates { get; set; }
    }
}
