using Blog.Core.Dto;
using System;

namespace Blog.Core.Models
{
    public class UserDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}