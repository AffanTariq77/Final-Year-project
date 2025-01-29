using AdventureAdorn.API;
using AdventureAdorn.API.Repository;
using AdventureAdorn.API.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AdvanturAdornContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();

builder.Services.AddScoped<IUserServices, UserServices>();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod());
});

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}


var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWorkRepository>();
//    unitOfWork.Context.Database.Migrate();
//}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();

app.MapControllers();

app.Urls.Add("http://localhost:5001");

app.Run();
