using Blog.Core.Commands;
using Blog.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class ArticleController : Controller
    {
        private readonly IMediator _mediator;

        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            var request = new GetArticlesQuery();
            var data = await _mediator.Send(request);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(string subject, string body)
        {
            var request = new CreateArticleCommand(subject, body, Guid.NewGuid());
            var isSuccess = await _mediator.Send(request);

            if (isSuccess)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}