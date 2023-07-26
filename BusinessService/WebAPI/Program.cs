using Domain.Models;
using Domain.UnitOfWork;
using Infrastructure.DBContext;
using Infrastructure.Repositories;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Application.Services.AccountService;
using Application.Services.CustomerService;
using Application.Services.AppointmentService;
using Application.Services.StaffService;
using Application.Services.SpaService;
using Application.Services.DiscountService;
using Application.Services.ServiceService;
using Application.Services.AppointmentDetailService;
using Application.Services.PaymentService;
using Application.Services.ReviewService;
using Infrastructure.Repositories.Interfaces;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Host.UseSerilog((context, loggerConfig) => {
    loggerConfig
    .ReadFrom.Configuration(context.Configuration)
    .WriteTo.Console()
    .Enrich.WithMachineName()
    .Enrich.FromLogContext()
    .Enrich.WithEnvironmentName()
    .WriteTo.Seq("http://localhost:5341");
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<SpaBookingDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Host.UseSerilog((context, lc) => lc.WriteTo.Console().WriteTo.Seq("http://localhost:5341"));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IStaffRepository, StaffRepository>();
builder.Services.AddScoped<ISpaRepository, SpaRepository>();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IAppointmentDetailRepository, AppointmentDetailRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IAppointmentService, AppointmentService>();
builder.Services.AddTransient<IStaffService, StaffService>();
builder.Services.AddTransient<ISpaService, SpaService>();
builder.Services.AddTransient<IDiscountService, DiscountService>();
builder.Services.AddTransient<IServiceService, ServiceService>();
builder.Services.AddTransient<IAppointmentDetailService, AppointmentDetailService>();
builder.Services.AddTransient<IPaymentService, PaymentService>();
builder.Services.AddTransient<IReviewService, ReviewService>();



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SpaBookingDBContext>();
    await dbContext.Database.EnsureCreatedAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
