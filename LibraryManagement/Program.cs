using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Concretes;
using LibraryManagement.DataAccess.Contexts;
using LibraryManagement.Exceptions;
using LibraryManagement.Middlewares;
using LibraryManagement.Services.Abstracts;
using LibraryManagement.Services.BusinessRules;
using LibraryManagement.Services.Concretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddExceptionHandler<ExceptionHandlerConfig>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// IoC Kay�tlar�

// Dependency Injection LifeCycle
// AddScoped() : Her bir http iste�i Respons a d�nene kadar 1 tane nesne �retir.

// AddSingleton() : Uygulama ayakta oldu�u s�rece 1 tane nesne �retir.

// AddTransient() : Her bir istek ba��na 1 tane nesne �retir.

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<MongoDbContext>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<BaseDbContext>();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<BookBusinessRules>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseExceptionHandler(_ => { });

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
