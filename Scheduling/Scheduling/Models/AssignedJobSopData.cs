﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scheduling.Models
{
    public class AssignedJobSopData
    {
        public int JobSopId { get; set; }
        public string Title { get; set; }
        public bool Assigned { get; set; }
    }
}