using Catalog.Core.Application.Extensions;
using Catalog.Infrastructure.Identity.Extensions;
using Catalog.Infrastructure.Persistence.Extensions;
using Catalog.Presentation.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwagger();

builder.Services.AddApplication();

builder.Services.AddInfraPersistence(builder.Configuration);

builder.Services.AddInfraIdentity(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment()) { }

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.ExecuteMigrationPersistenceAsync();

await app.ExecuteMigrationIdentityAsync();

app.Run();
