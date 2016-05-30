﻿using FlatRent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlatRent.Web.Models.ViewModels
{
    public class FlatDetailViewModel
    {
        public Flat Flat { set; get; }
        public List<Facility> Facilities { set; get; }
    }
}