﻿using Microsoft.AspNetCore.Http;
using MVCStartApp.Models.Db;
using MVCStartApp.Repository;

namespace MVCStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context, IUserRequest userRequest)
        {
            // Для логирования данных о запросе используем свойста объекта HttpContext
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");

            var request = new UserRequest()
            {
                Date = DateTime.Now,
                Url = $"{context.Request.Host.Value + context.Request.Path}"
            };
            userRequest.AddRequest(request);

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
