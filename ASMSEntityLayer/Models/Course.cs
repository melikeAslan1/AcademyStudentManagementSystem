﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSEntityLayer.Models
{
    [Table("Course")]
    public class Course: Base<int>
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Kurs adı az 2 en çok 50 karakter aralığında olmalıdır!")]

        public string CourseName { get; set; }





    }
}
