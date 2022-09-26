using SixLabors.ImageSharp.Web.DependencyInjection;

namespace tvingsbakken.org;

public class Startup
{
    private readonly IWebHostEnvironment _env;
    private readonly IConfiguration _config;

    /// <summary>
    /// Initializes a new instance of the <see cref="Startup" /> class.
    /// </summary>
    /// <param name="webHostEnvironment">The web hosting environment.</param>
    /// <param name="config">The configuration.</param>
    /// <remarks>
    /// Only a few services are possible to be injected here https://github.com/dotnet/aspnetcore/issues/9337.
    /// </remarks>
    public Startup(IWebHostEnvironment webHostEnvironment, IConfiguration config)
    {
        _env = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
        _config = config ?? throw new ArgumentNullException(nameof(config));
    }

    /// <summary>
    /// Configures the services.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <remarks>
    /// This method gets called by the runtime. Use this method to add services to the container.
    /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940.
    /// </remarks>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddUmbraco(_env, _config)
            .AddBackOffice()
            .AddWebsite()
            .AddComposers()
            .Build();

        services.AddImageSharp(options =>
        {
            options.OnParseCommandsAsync = c =>
            {
                if (c.Context is not null)
                {
                    if (c.Context.Request.GetTypedHeaders().Accept
                            .Any(aValue => aValue.MediaType.Value == "image/webp"))
                    {
                        var path = c.Context.Request.Path.ToString();

                        if (!c.Commands.Contains("webp") || !c.Commands.Contains("noformat") && path.EndsWith(".png") || path.EndsWith(".jpg") || path.EndsWith(".jpeg"))
                        {
                            c.Commands.Remove("format");
                            c.Commands.Add("format", "webp");
                            c.Context.Response.Headers.Add("Vary", "Accept");
                        }
                    }
                }

                bool doesntWantFormat = c.Commands.TryGetValue("noformat", out string value);

                if (doesntWantFormat)
                {
                    c.Commands.Remove("format");
                }
                return Task.CompletedTask;
            };
        });
    }

    /// <summary>
    /// Configures the application.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <param name="env">The web hosting environment.</param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // Add caching on static files like .CSS .JS and .SVG and .WOFF2
        app.Use(async (context, next) =>
        {
            context.Response.Headers.Add("X-Xss-Protection", "1; mode=block");
            context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
            context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
            context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000");

            string path = context.Request.Path;

            if (path.StartsWith("/umbraco/") == false)
            {
                if (path.EndsWith(".css") || path.EndsWith(".js") || path.EndsWith(".svg") || path.EndsWith(".woff2") || (path.EndsWith(".png") && path.StartsWith("/assets/")))
                {
                    context.Response.Headers.Add("Cache-Control", "public, max-age=31536000");
                }
            }
            if (path.StartsWith("/media/") && !path.EndsWith(".pdf"))
            {
                context.Response.Headers.Add("Cache-Control", "public, max-age=2592000");
            }

            await next();
        });

        app.UseUmbraco()
            .WithMiddleware(u =>
            {
                u.UseBackOffice();
                u.UseWebsite();
            })
            .WithEndpoints(u =>
            {
                u.UseInstallerEndpoints();
                u.UseBackOfficeEndpoints();
                u.UseWebsiteEndpoints();
            });

        app.UseImageSharp();
    }
}
