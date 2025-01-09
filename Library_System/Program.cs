using Library_System.AppDbContext;
using Library_System.Repositorys.AuthorRepo;
using Library_System.Repositorys.BookRepo;
using Library_System.Repositorys.CreditCardRepo;
using Library_System.Repositorys.GenreRepo;
using Library_System.Repositorys.IdentityCardRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connection = builder.Configuration.GetConnectionString("myconnection");
builder.Services.AddDbContext<dbcontext>(options => options.UseSqlServer(connection));


builder.Services.AddControllers();


builder.Services.AddScoped<IAuthorRepo, RepoAuthor>();
builder.Services.AddScoped<IBookRepo, RepoBook>();
builder.Services.AddScoped<ICreditRepo, CreditRepo>();
builder.Services.AddScoped<IGenreRepo, RepoGenre>();
builder.Services.AddScoped<IRepoIdentityCard, IdentityRepo>();





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
