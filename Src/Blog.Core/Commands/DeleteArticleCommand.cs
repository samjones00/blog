using MediatR;
using System;

namespace Blog.Core.Commands
{
    public class DeleteArticleCommand : IRequest<bool>
    {
        public Guid ArticleId { get;}

        public DeleteArticleCommand(Guid articleId)
        {
            ArticleId = articleId;
        }
    }
}
