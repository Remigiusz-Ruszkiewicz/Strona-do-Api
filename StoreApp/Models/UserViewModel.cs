﻿using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    public class UserViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
