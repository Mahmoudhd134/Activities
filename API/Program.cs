using API.Helpers;
using Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceConfigurations(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.UseUpdateDatabaseIfFound();
await app.UseAddDummyDataIfEmpty();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();