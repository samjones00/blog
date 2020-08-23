using Blog.Core.Dto;
using System;

namespace Blog.Core.Models
{
    public class ArticleDto : BaseDto
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid UserId { get; set; }
    }
}