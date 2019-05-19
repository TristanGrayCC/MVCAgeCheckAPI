using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCAgeCheck.Dtos
{
    public class UserDto
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "EmailAddress")]
        public string Email { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [Display(Name = "Date of Birth"), DataType(DataType.Date)]
        [Range(typeof(DateTime), "1900/01/01", "2010/01/01")]
        public DateTime DateOfBirth { get; set; }

        public virtual List<LoginDto> Logins { get; set; }
    }
}
