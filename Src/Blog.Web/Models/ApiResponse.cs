﻿namespace Blog.Web.Models
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
    }
}
