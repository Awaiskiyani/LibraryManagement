﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    internal class Book
    {
        public string ISBN { get; set; }
        public string? Title { get; set; }
        public string?  Author { get; set; }
        public bool IsAvailable { get; set; } = true;
        public User ToUser { get; set; }


    }
}
