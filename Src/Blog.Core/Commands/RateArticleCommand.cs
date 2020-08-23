using MediatR;
using System;

namespace Blog.Core.Commands
{
    public class RateArticleCommand : IRequest<bool>
    {
        public int Rating { get; set; }
        public Guid ArticleId { get; set; }
        public Guid UserId { get; set; }
    }
}