﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.ViewModels.System.Users
{
    public class UserUpdateRequest
       
    { 
        public Guid Id { get; set; }

        [Display(Name = "Họ")]
        public string FirstName { get; set; }

        [Display(Name = "Tên")]
        public string LastName { get; set; }

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime Dob { get; set; }

    }
}
