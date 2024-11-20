using System.Reflection;
using AceBackend.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;
using AceBackend.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

/*builder.Services.AddMediatR(configuration =>
    configuration.RegisterServicesFromAssembly(typeof(Program).Assembly)
    );
*/
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();


