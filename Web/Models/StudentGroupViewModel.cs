﻿using BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class StudentGroupViewModel
    {
        public List<StudentGroupDTO> StudentGroups { get; set; }

        public StudentGroupViewModel () 
        {
            StudentGroups = new List<StudentGroupDTO>();
        }
    }
}