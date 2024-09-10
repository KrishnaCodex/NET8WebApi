namespace NET8WebApi.Middlewares
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke (HttpContext context)
        {
            Console.WriteLine("Custom Middleware before next");

            await _next(context);

            Console.WriteLine("Custom Middleware after next");
        }
    }
}
