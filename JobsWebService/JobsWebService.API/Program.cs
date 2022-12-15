using JobsWebService.API.Core.Configurartions;
using JobsWebService.API.Core.Services;
using JobsWebService.API.Core.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});
builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddScoped<IJobQuotationCalculator, JobQuotationCalculator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
