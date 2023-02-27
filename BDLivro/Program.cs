/*var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

app.Run();*/

using BDLivro.Data;
using BDLivro.Models;

using LivrosContexto context = new LivrosContexto();



/*Autor AutorInfo = new Autor()
{
    NomeAutor = "Mariana"
};



Livros LivroInfo = new Livros()
{          
    isbn = 2134567890,
    nomeLivro = "A saga do Touros",
    precoLivro = (decimal)25.99,
    Autor = AutorInfo
};



context.Add(AutorInfo);
context.Add(LivroInfo);*/

context.SaveChanges();

/*var livros = context.Livros
    .Where(l => l.precoLivro > (decimal)10.99)
    .OrderBy(l => l.nomeLivro);

foreach (Livros l in livros)
{
    Console.WriteLine($"ID: {l.ID}" );
    Console.WriteLine($"ISBN: {l.isbn}");
    Console.WriteLine($"Nome: {l.nomeLivro}");
    Console.WriteLine($"Preço: {l.precoLivro}");
    Console.WriteLine($"AutorID: {l.AutorId}");
    Console.WriteLine($"Apagado? {l.Apagado}");
    Console.WriteLine(new string ('-', 20));
}*/

