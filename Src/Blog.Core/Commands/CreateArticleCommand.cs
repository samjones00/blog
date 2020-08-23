using MediatR;
using System;

namespace Blog.Core.Commands
{
    public class CreateArticleCommand : IRequest<bool>
    {
        public string Subject { get; }
        public string Body { get; }
        public Guid UserId { get; }

        public CreateArticleCommand(string subject, string body, Guid userId)
        {
            Subject = subject;
            Body = body;
            UserId = userId;
        }
    }
}
