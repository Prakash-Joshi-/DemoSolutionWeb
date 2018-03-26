﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_API_Cache_Demo.Models
{
    public class DateNumberObject
    {
        public DateTime CurrentDate { get; set; }
        public int RandomNumber { get; set; }

        public DateNumberObject()
        {
            CurrentDate = DateTime.Now;
            Random rand = new Random();
            RandomNumber = rand.Next(1, 200);
        }
    }
}