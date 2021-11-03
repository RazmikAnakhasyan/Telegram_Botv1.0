﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Currency
    {
        public Currency()
        {
            RateFromCurrencyNavigations = new HashSet<Rate>();
            RateToCurrencyNavigations = new HashSet<Rate>();
        }

        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Rate> RateFromCurrencyNavigations { get; set; }
        public virtual ICollection<Rate> RateToCurrencyNavigations { get; set; }
    }
}
