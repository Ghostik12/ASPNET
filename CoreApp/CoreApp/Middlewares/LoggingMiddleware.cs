namespace CoreApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private void LogConcole(HttpContext context)
        {
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
        }

        private async Task LogFile(HttpContext context)
        {
            var logMessage = $"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path} {Environment.NewLine}";

            var logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "RequestLog.txt");

            await File.AppendAllTextAsync(logFilePath, logMessage);
        }

        public async Task InvokeAsync(HttpContext context)
        {
            LogConcole(context);
            await LogFile(context);

            await _next.Invoke(context);
        }
    }
}
