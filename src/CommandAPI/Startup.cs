using CommandAPI.Data;

public class Startup
{
	public IConfiguration Configuration { get; }
	public Startup(IConfiguration configuration)
	{
		this.Configuration = configuration;
	}

	// This method gets called by the runtime. Use this method to add services to the container.
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddControllers();
		// Dependency injection
		services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();
	}
	// This method gets called by the runtime. Use this method to configure HTTP request pipeline
	public void Configure(WebApplication app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}

		app.UseRouting();

		app.UseEndpoints(endpoints =>
		{
			endpoints.MapControllers();
		});
	}
}

