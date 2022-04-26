﻿using ASMSEntityLayer.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSEntityLayer.IdentityModels
{
    class AppUser:IdentityUser
    {
        [DataType(DataType.DateTime)]
        public DateTime RegisterDate { get; set; }=DateTime.Now;



        [Required(ErrorMessage ="İsim Gereklidir!")]
        [StringLength(50, MinimumLength =2, ErrorMessage ="İsminiz en az 2 en çok 50 karakter olmalıdır!")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Soyisim Gereklidir!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Soyisminiz en az 2 en çok 50 karakter olmalıdır!")]
        public string Surname { get; set; }



        [StringLength(11, MinimumLength = 11, ErrorMessage = "TC 11 haneli olmalıdır!")]
        public string TCNumber { get; set; }
        public string Picture { get; set; }



        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; } //? koyduk nullable a izin versin diye.



        [Required(ErrorMessage = "Cinsiyet Gereklidir!")]
        public Genders Gender { get; set; } //Enumarable

    }
}