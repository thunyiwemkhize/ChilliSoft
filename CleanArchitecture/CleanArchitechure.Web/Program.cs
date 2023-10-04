using CleanArchitechure.InMemoryDB;
using CleanArchitechure.Web.Presenters;
using CleanArchitecture.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICreateUserUseCase, CreateUserUseCase>();
builder.Services.AddTransient<IUserGateway, InMemoryUserGateway>();
builder.Services.AddTransient<IActionResultPresenter, RestPresenter>();


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
