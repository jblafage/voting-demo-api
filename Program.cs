using api_voting_demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add Postgres Entity framework service
builder.Services.AddEntityFrameworkNpgsql();

// Connection to Postgres database
builder.Services.AddDbContext<VotingDbContext>
    (options => options.UseNpgsql(builder.Configuration.GetConnectionString("VotingDb")));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Register the Swagger generator, defining 1 or more Swagger documents
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Voting API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// Enable standard ASP.NET Core metrics
app.UseMetricServer();
app.UseHttpMetrics();

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

//// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
//// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Voting API V1");
    c.RoutePrefix = string.Empty;
});

// Run automatically Entity migrations
try
{
    using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
   serviceScope.ServiceProvider.GetService<VotingDbContext>().Database.Migrate();
}
catch (Exception ex)
{
    app.Logger.LogError(ex, "Failed to migrate or seed database");
}

app.MapControllers();

app.Run();