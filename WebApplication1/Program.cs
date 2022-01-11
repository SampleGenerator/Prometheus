using Microsoft.Extensions.Options;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddHttpClient(Options.DefaultName)
    .UseHttpClientMetrics();

builder.Services
    .AddHealthChecks()
    .ForwardToPrometheus();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpMetrics();
app.UseMetricServer();

app.UseAuthorization();

app.MapControllers();

app.Run();
