
using ABCFitnessClassBooking.Interfaces;
using ABCFitnessClassBooking.Models;
using ABCFitnessClassBooking.Repository;
using ABCFitnessClassBooking.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton <List<DailyClassesDetailsModel>>(new List<DailyClassesDetailsModel>());
builder.Services.AddSingleton<List<ClassDetailsModel>>(new List<ClassDetailsModel>());
builder.Services.AddSingleton<List<BookingDetailsModel>>(new List<BookingDetailsModel>());

builder.Services.AddSingleton<IClassesService, ClassesService>();
builder.Services.AddSingleton<IClassBookingService, ClassBookingService>();

builder.Services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
