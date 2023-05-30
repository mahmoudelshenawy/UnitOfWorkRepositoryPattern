using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkRepositoryPattern.Api.DependencyInjection;
using UnitOfWorkRepositoryPattern.Core.Interfaces;
using UnitOfWorkRepositoryPattern.EFCore;
using UnitOfWorkRepositoryPattern.EFCore.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services
    .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ,
    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
    ));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
////builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
//builder.Services.AddAutoMapper(typeof(Program));

builder.Services.InjectServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
