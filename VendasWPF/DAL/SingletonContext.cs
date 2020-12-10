﻿using System;
using System.Collections.Generic;
using System.Text;
using VendasWPF.Models;

namespace VendasWPF.DAL
{
    class SingletonContext
    {
        private static Context _context;

        public static Context GetInstance()
        {
            if (_context == null)
            {
                _context = new Context();
            }
            return _context;
        }
    }
}
