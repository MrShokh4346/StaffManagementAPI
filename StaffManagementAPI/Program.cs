using Microsoft.EntityFrameworkCore;
using StaffManagement.DataAccess.Models;
using StaffManagement.DataAccess;
using StaffManagementAPI.Models;
using SQLServerStaffRepositiry = StaffManagement.DataAccess.Models.SQLServerStaffRepositiry;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddScoped<IStaffRepository, SQLServerStaffRepositiry>();
builder.Services.AddDbContextPool<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StaffDb")));


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseMvcWithDefaultRoute();
//app.UseMvc(routerBuilder =>
//{
//    routerBuilder.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
//});
//app.UseMvc();

app.UseAuthorization();

app.Run();
