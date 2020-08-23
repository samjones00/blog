using FluentValidation;

namespace Blog.Core
{
    public class ArticleValidator : AbstractValidator<Models.ArticleDto>
	{
		public ArticleValidator()
		{
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.Subject).Length(0, 10);
            RuleFor(x => x.Body).Length(0, 100);
        }
	}
}
