using System;

namespace Blog.Core.Dto
{
    public class BaseDto
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}