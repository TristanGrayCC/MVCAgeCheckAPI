using System;
using System.Collections.Generic;

namespace MVCAgeCheck.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual List<LoginDto> Logins { get; set; }
    }
}
