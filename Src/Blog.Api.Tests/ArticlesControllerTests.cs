using Blog.Controllers;
using Blog.Core.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Hosting;
using Blog.Core.Dto;

namespace Blog.Api.Tests
{
    public class ArticlesControllerTests
    {
        IMediator _mediator;

        public ArticlesControllerTests()
        {
            _mediator = Substitute.For<IMediator>();
        }

        [Fact]
        public async Task CreateArticle_GivenValidData_ShouldReturnOK()
        {
            var subject = "Article Subject";
            var body = "Article Body";

            _mediator.Send(Arg.Any<CreateArticleCommand>()).Returns(true);

            var controller = new ArticlesController(_mediator);

            var request = new CreateArticleDto { Subject = subject, Body = body };

            IActionResult result = await controller.CreateArticle(request);

            Assert.IsAssignableFrom<IActionResult>(result);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task GetArticles_GivenNoQuery_ReturnsArticles()
        {
            var controller = new ArticlesController(_mediator);

            var result = await controller.GetArticles();

            Assert.IsAssignableFrom<IActionResult>(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetArticles_ApiRequest_ReturnsArticles()
        {
            var server = new Microsoft.AspNetCore.TestHost.TestServer(new WebHostBuilder().UseStartup<Startup>());
            var client = server.CreateClient();


            var response = await client.GetAsync("/articles");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.Equal("Hello World!", responseString);
        }
    }
}