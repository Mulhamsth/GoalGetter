﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using MudBlazor;
using System.Threading.Tasks;
using Libraries.DistanceAddressCalculator;

namespace GG.CoreBusiness
{
    public class Person
    {
        public int Id { get; set; }
        public string AvatarPath { get; set; } = null;

        public Color AvatarColor { get; set; } = Color.Primary;


        [Required, StringLength(100, MinimumLength = 1, ErrorMessage = "Firstname must be between 1 and 100 characters")]
        public string Firstname { get; set; }


        [Required, StringLength(100, MinimumLength = 1, ErrorMessage = "Lastname must be between 1 and 100 characters")]
        public string Lastname { get; set; }


        [StringLength(300, ErrorMessage = "Address can't be longer than 300 characters")]
        public Address Address { get; set; }


        [Required, StringLength(320, MinimumLength = 5, ErrorMessage = "Invalid Email Address. Must be between 5 and 320 characters")]
        public string Email { get; set; }


        [StringLength(200, ErrorMessage = "Phone number can't be longer then 200 characters")]
        public string Phone { get; set; }
    }
}
