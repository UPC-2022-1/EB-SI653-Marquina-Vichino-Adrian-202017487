using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using si653ebu202017487.API.MagnetArt.Painting.Domain.Repositories;
using si653ebu202017487.API.MagnetArt.Painting.Domain.Services;
using si653ebu202017487.API.MagnetArt.Painting.Persistence.Repositories;
using si653ebu202017487.API.MagnetArt.Painting.Services;
using si653ebu202017487.API.MagnetArt.Training.Domain.Repositories;
using si653ebu202017487.API.MagnetArt.Training.Domain.Services;
using si653ebu202017487.API.MagnetArt.Training.Persistence.Repositories;
using si653ebu202017487.API.MagnetArt.Training.Services;
using si653ebu202017487.API.Security.Authorization.Middleware;
using si653ebu202017487.API.Shared.Domain.Repositories;
using si653ebu202017487.API.Shared.Persistence.Contexts;
using si653ebu202017487.API.Shared.Persistence.Repositories;
using si653ebu202017487.Shared.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors();


builder.Services.AddSwaggerGen(options => {
	options.SwaggerDoc("v1", new OpenApiInfo {
		Version = "v1",
		Title = "magnet.art API",
		Description = "MAGnet RESTful API",
		TermsOfService = new Uri("https://magnet.art/tos"),
		Contact = new OpenApiContact {
			Name = "magnet.art",
			Url = new Uri("https://magnet.art")
		},
		License = new OpenApiLicense {
			Name = "MAGnet Resources License",
			Url = new Uri("https://magnet.art/license")
		}
	});
	options.EnableAnnotations();
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
	options => options.UseMySQL(connectionString)
		.LogTo(Console.WriteLine, LogLevel.Information)
		.EnableSensitiveDataLogging()
		.EnableDetailedErrors());

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
builder.Services.AddScoped<IProviderService, ProviderService>();




builder.Services.AddAutoMapper(
	  typeof(si653ebu202017487.API.MagnetArt.Painting.Mapping.ModelToResourceProfile),
	  typeof(si653ebu202017487.API.MagnetArt.Painting.Mapping.ResourceToModelProfile),
	  typeof(si653ebu202017487.API.MagnetArt.Training.Mapping.ModelToResourceProfile),
	  typeof(si653ebu202017487.API.MagnetArt.Training.Mapping.ResourceToModelProfile)
	  );


var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>()) {
	context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI(options => {
		options.SwaggerEndpoint("v1/swagger.json", "v1");
		options.RoutePrefix = "swagger";
	});
}


app.UseCors(x => x
	.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader());

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
