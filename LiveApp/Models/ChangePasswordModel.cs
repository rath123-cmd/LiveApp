﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiveApp.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "This field is required."), DataType(DataType.Password), Display(Name = "Current Password: ")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "This field is required."), DataType(DataType.Password), Display(Name = "New Password: ")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "This field is required."), DataType(DataType.Password), Display(Name = "Confirm New Password: ")]
        public string ConfirmNewPassword { get; set; }
    }
}
