using Microsoft.EntityFrameworkCore;
using Pandape.Business.Commands;
using Pandape.Business.Interfaces;
using Pandape.Business.Queries;
using Pandape.Data;
using Pandape.Data.Command;
using Pandape.Data.Dto;
using Pandape.Data.Query;
using Pandape.Data.Repository;
using Pandape.Service;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "PandapeAPI",
        Description = "Technical Test Service"
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddDbContext<DataContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:PruebaP"]);
});

builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<ICommandHandler<CreateCandidateCommand, int>, CreateCandidateCommandHandler>();
builder.Services.AddScoped<ICommandHandler<UpdateCandidateCommand, int>, UpdateCandidateCommandHandler>();
builder.Services.AddScoped<ICommandHandler<DeleteCandidateCommand, int>, DeleteCandidateCommandHandler>();
builder.Services.AddScoped<IQueryHandler<GetCandidateQuery, CandidateDto>, GetCandidateQueryHandler>();
builder.Services.AddScoped<IQueryHandler<GetCandidatesQuery, List<CandidateDto>>, GetCandidatesQueryHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
