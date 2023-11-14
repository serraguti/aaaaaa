using FevalAWSComicsRDS.Data;
using FevalAWSComicsRDS.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//DEBEMOS INDICAR QUE VAMOS A UTILIZAR EL REPOSITORY EN NUESTRA APP
builder.Services.AddTransient<RepositoryComics>();
string connectionStringMySqlLocal =
    "server=localhost; port=3306; user id=root; password=mysql; database=ejemplo";
//ENVIAMOS LA CADENA DE CONEXION A NUESTRO CONTEXT PARA PODER 
//COMUNICAR CON LA BASE DE DATOS
builder.Services.AddDbContext<ComicsContext>
    (options => options.UseMySql(connectionStringMySqlLocal
    , ServerVersion.AutoDetect(connectionStringMySqlLocal)));
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
