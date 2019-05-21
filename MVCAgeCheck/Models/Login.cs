using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCAgeCheck.Models
{
    public class Login
    {

        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public bool Successful { get; set; }
    }
}
