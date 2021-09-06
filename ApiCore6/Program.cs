using BusinessCore6;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ApiCore6", Version = "v1" });
});

builder.Services.AddScoped<ISectionService, SectionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiCore6 v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("section/{id}", async (ISectionService sectionService, int id) => await sectionService.ReadAsync(id));



app.MapControllers();

app.Run();
