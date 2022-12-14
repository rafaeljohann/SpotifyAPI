using Spotify.CrossCutting.ValidationBehavior;
using Spotify.Infra.CrossCutting.Ioc;
using Spotify.Infra.CrossCutting.Notifications;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => 
{
    options.Filters.Add<NotificationFilter>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediator();
builder.Services.AddServices();
builder.Services.AddSettings(builder.Configuration);
builder.Services.AddApiServices(builder.Configuration);
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();
app.UseMiddleware(typeof(ErrorHandlingMiddleware));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
