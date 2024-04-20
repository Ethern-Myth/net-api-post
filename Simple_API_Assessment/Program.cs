using Microsoft.EntityFrameworkCore;
using Simple_API_Assessment.Data;
using Simple_API_Assessment.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/** PostgreSQL connection
*/

builder.Services.AddDbContext<DataContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

/**
 * Using generics to allow single to multiple register through one Application Repository
 * EXAMPLE:
 * builder.Services.AddScoped<IApplicantRepository<Applicant>, ApplicantRepo<Applicant>>();
*/
builder.Services.AddScoped<IApplicantRepository, ApplicantRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Check if database connects and push the migration
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();
    if (!context.Database.CanConnect())
        context.Database.Migrate();
}

app.Run();
