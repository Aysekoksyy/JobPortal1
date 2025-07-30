using JobPortal1.Data;  // DbContext için gerekli using
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Swagger (API dokümantasyonu) için gerekli
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS politikası tanımlanıyor
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// EF Core DbContext servis olarak ekleniyor
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controller'lar ve Razor View'lar
builder.Services.AddControllersWithViews();
builder.Services.AddControllers(); // API Controller'lar için gerekli

var app = builder.Build();

// Swagger devreye alınıyor
app.UseSwagger();
app.UseSwaggerUI();

// Geliştirme ortamı değilse özel hata sayfası ve HSTS kullan
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// HTTPS yönlendirme ve statik dosyalar
app.UseHttpsRedirection();
app.UseStaticFiles();

// CORS middleware
app.UseCors("AllowAll");

// Hata sayfası yönlendirmesi
app.UseStatusCodePagesWithReExecute("/Pages/PageNotFound");

app.UseRouting();
app.UseAuthorization();

// MVC controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// ✅ API Controller'lar devreye giriyor
app.MapControllers();

app.Run();

