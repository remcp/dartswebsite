//bullseyebuddy
global using DAL.Data;
using DAL;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenDAL at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDataServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<IDBaccess, Dbaccess>();
//builder.Services.AddSingleton<IPlayerdata, Playerdata>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureApi();

app.Run();