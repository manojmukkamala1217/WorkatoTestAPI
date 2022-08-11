using WorkatoTestAPI.Contracts;
using WorkatoTestAPI.Domain;
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

builder.Services.AddHttpClient();
builder.Services.AddScoped<IHttpClientProviderService, HttpClientProviderService>();

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
