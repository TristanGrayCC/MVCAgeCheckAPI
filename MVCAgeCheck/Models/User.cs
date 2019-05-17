using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCAgeCheck.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual List<Login> Logins { get; set; }
}
}
