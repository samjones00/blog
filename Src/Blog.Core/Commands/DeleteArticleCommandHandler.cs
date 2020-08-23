using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Core.Commands
{
    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, bool>
    {
        public Task<bool> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            //delete article
            return Task.FromResult(true);
        }
    }
}
