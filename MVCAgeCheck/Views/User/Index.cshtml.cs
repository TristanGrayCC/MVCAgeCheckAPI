using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVCAgeCheck.Dtos;
using System;

namespace MVCAgeCheck.Views.User
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public UserDto UserInput { get; set; }
        public void OnPost(string json)
        {
            Console.WriteLine(json);
        }
    }
}