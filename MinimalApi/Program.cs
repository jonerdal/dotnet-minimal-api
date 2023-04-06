using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using MinimalApi.Dtos;
using MinimalApi.Models;
using MinimalApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CommandDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteDbConnection")));
builder.Services.AddScoped<ICommandRepository, CommandRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Endpoints

var basePattern = "api/v1/commands";

app.MapGet(basePattern, async (ICommandRepository repo, IMapper mapper) => {
    var commands = await repo.GetCommandsAsync();
    return Results.Ok(mapper.Map<IEnumerable<CommandReadDto>>(commands));
});

app.MapGet($"{basePattern}/{{id}}", async (ICommandRepository repo, IMapper mapper, Guid id) => {
    var command = await repo.GetCommandByIdAsync(id);

    if(command == default)
    {
        return Results.NotFound();
    }
    
    return Results.Ok(mapper.Map<CommandReadDto>(command));
});

app.MapPost(basePattern, async (ICommandRepository repo, IMapper mapper, CommandCreateDto commandDto) => {

    if(commandDto == null) {
        return Results.UnprocessableEntity();
    }

    var command = mapper.Map<Command>(commandDto);
    await repo.CreateCommandAsync(command);
    await repo.SaveChangesAsync();

    return Results.Created($"{basePattern}/{command.Id}", mapper.Map<CommandReadDto>(command));
});

app.MapPut($"{basePattern}/{{id}}", async (ICommandRepository repo, IMapper mapper, CommandUpdateDto commandDto, Guid id) => {

    var command = await repo.GetCommandByIdAsync(id);
    
    if(command == default) {
        return Results.NotFound();
    }

    mapper.Map(commandDto, command);
    await repo.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete($"{basePattern}/{{id}}", async (ICommandRepository repo, Guid id) => {
    
    var command = await repo.GetCommandByIdAsync(id);
    
    if(command == default) {
        return Results.NotFound();
    }

    repo.DeleteCommand(command);
    await repo.SaveChangesAsync();

    return Results.NoContent();
});

#endregion Endpoints

app.Run();