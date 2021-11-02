﻿using DataAccess.Models;
using Shared.Models.Banks;
using Shared.Models.Rates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly DBModel _context;
        public BankRepository(DBModel context)
        {
            _context = context;
        }

      public  IEnumerable<Rate> All()
        {
            return _context.Rates;
        }
    }
}