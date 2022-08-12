using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WorkatoTestAPI.Contracts;
using WorkatoTestAPI.Domain;
using WorkatoTestAPI.Repository;
using WorkatoTestAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(_ =>
{
    WorkatoApiOptions workatoApiOptions = new();
    builder.Configuration.Bind("WorkatoApiOptions", workatoApiOptions);
    return workatoApiOptions;
});

builder.Services.AddDbContext<EnginuityContext>(options =>
                       options.UseSqlServer(builder.Configuration.GetConnectionString("EnginuityConnection")));

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddHttpClient();
builder.Services.AddTransient<IHttpClientService, HttpClientService>();
builder.Services.AddTransient<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<IMapperService, MapperService>();
builder.Services.AddTransient<ISellerService, SellerService>();
builder.Services.AddTransient<IWorkatoService, WorkatoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WorkatoAPIRecipe v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();