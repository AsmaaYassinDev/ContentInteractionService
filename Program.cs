using ContentInteractionService.Interfaces;
using ContentInteractionService.Service;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register Cosmos DB client
builder.Services.AddSingleton<CosmosClient>(sp =>
{
    var cosmosConnectionString = "your-cosmos-db-connection-string";
    return new CosmosClient(cosmosConnectionString);
});

// Register the ContentService
builder.Services.AddScoped<IContentService, ContentService>();

// Register CommentService and RatingService
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IRatingService, RatingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();
app.MapControllers();

app.Run();
