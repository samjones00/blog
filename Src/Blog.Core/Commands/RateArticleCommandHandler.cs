using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Core.Commands
{
    public class RateArticleCommandHandler : IRequestHandler<RateArticleCommand, bool>
    {
        private readonly IMediator _mediator;

        public RateArticleCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<bool> Handle(RateArticleCommand request, CancellationToken cancellationToken)
        {
            //set rating 
            return Task.FromResult(true);
        }
    }
}
