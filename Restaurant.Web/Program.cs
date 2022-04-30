using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Data.Common;
using Restaurant.Data.Common.Persistance;
using Restaurant.Data.Entities.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RestaurantDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantDB")));

builder.Services.AddIdentityCore<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddEntityFrameworkStores<RestaurantDbContext>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
