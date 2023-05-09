﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG.CoreBusiness
{
    public class Person
    {
        public string Id { get; init; }
        public string AvatarPath { get; set; }


        [Required, StringLength(100, MinimumLength = 1, ErrorMessage = "Firstname must be between 1 and 100 characters")]
        public string Firstname { get; set; }


        [Required, StringLength(100, MinimumLength = 1, ErrorMessage = "Lastname must be between 1 and 100 characters")]
        public string Lastname { get; set; }


        [StringLength(300, ErrorMessage = "Address can't be longer than 300 characters")]
        public string Address { get; set; }


        [Required, StringLength(320, MinimumLength = 5, ErrorMessage = "Invalid Email Address. Must be between 5 and 320 characters")]
        public string Email { get; set; }


        [StringLength(200, ErrorMessage = "Phone number can't be longer then 200 characters")]
        public string Phone { get; set; }
    }
}
