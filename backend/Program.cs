using System.Linq;
using backend.Data;
using backend.Interface;
using backend.Services;
using backend.Integrations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Mapping
builder.Services.AddDbContext<AppDbContext>(options =>{
    options.UseSqlite("Data Source=Data/app.db");
});
builder.Services.AddScoped<IJobService,JobService>();
builder.Services.AddHttpClient<NavApiService>();
builder.Services.AddScoped<JobMatchService>();
builder.Services.AddCors(options =>
{
options.AddPolicy("AllowFrontend",
    policy =>{
        policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
});
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.MapControllers();
app.MapGet("/", () => {
    return "Welcome to AI JOB Match";
});
app.Run();
