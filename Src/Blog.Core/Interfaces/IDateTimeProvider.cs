 using System;

namespace Blog.Core.Providers
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }

        DateTime GetUtcDate() { return UtcNow; }
    }
}