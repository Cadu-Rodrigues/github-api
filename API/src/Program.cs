using API.Repositories;
using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<IRepositoriesRepository, RepositoriesRepository>();
builder.Services.AddHostedService<SaveRepositoriesWorker>();
builder.Services.AddDbContext<RepositoriesContext>(options =>
   options.UseNpgsql(builder.Configuration.GetConnectionString("RepositoriesContext")));
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin();
        });
});
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
   var services = scope.ServiceProvider;
   try
   {
       // add 10 seconds delay to ensure the db server is up to accept connections
       // this won't be needed in real world application
       System.Threading.Thread.Sleep(10000);
       var context = services.GetRequiredService<RepositoriesContext>();
       var created = context.Database.EnsureCreated();

   }
   catch (Exception ex)
   {
       var logger = services.GetRequiredService<ILogger<Program>>();
       logger.LogError(ex, "An error occurred creating the DB.");
   }
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors();
app.Urls.Add("http://*:5000");
app.MapControllers();

app.Run();
