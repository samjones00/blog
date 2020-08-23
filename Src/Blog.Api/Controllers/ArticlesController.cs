using Blog.Core.Commands;
using Blog.Core.Dto;
using Blog.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class ArticlesController : Controller
    {
        private readonly IMediator _mediator;

        public ArticlesController(IMediator mediator)
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
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateArticle(CreateArticleDto request)
        {
            var command = new CreateArticleCommand(request.Subject, request.Body, Guid.NewGuid());
            var isSuccess = await _mediator.Send(command);

            if (isSuccess)
            {
                return Created(string.Empty, isSuccess);
            }

            return BadRequest();
        }
    }
}