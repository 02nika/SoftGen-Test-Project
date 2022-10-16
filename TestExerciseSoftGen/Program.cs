global using DataAccess.Data;
global using Microsoft.EntityFrameworkCore;
using DataAccess.Data.Abtract;
using DataAccess.Library;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(General.ConnectionString),
        b => b.MigrationsAssembly(General.WebProjectName));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IStudentContext, StudentContext>();
builder.Services.AddScoped<ITeacherContext, TeacherContext>();
builder.Services.AddScoped<IGroupContext, GroupContext>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
