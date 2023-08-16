namespace WebCore1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello1");
                await next();
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello3");
                await next();
            });
            app.Map("/api",  z=> {
                z.Run(async context =>
            {
                await context.Response.WriteAsync("api called");
            });
            });
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello2");

            });


            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello1");

            });
            app.MapGet("/", () => "Hello World!");
            app.Run();
        }
    }
}