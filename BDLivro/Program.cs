using BDLivro.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LivrosContexto>(options => options.UseSqlServer(@"Data Source=LENOVOESTAGIO\SQLEXPRESS;
            Initial Catalog=BDLivroTeste;Integrated Security=True;
            Connect Timeout=30;TrustServerCertificate=True;"));

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
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

//using BDLivro.Data;
//using BDLivro.Models;

//using LivrosContexto context = new LivrosContexto();

//Autor AutorInfo = new Autor()
//{
//    NomeAutor = "Jo?o"
//};



//Livros LivroInfo = new Livros()
//{          
//    isbn = 1222222222,
//    nomeLivro = "A saga de Peixes",
//    precoLivro = (decimal)20.00,
//    AutorId = 1
//    //Autor = AutorInfo
//};



//context.Add(AutorInfo);
//context.Add(LivroInfo);

//context.SaveChanges();

/*var livros = context.Livros
    .Where(l => l.precoLivro > (decimal)10.99)
    .OrderBy(l => l.nomeLivro);

foreach (Livros l in livros)
{
    Console.WriteLine($"ID: {l.ID}" );
    Console.WriteLine($"ISBN: {l.isbn}");
    Console.WriteLine($"Nome: {l.nomeLivro}");
    Console.WriteLine($"Pre?o: {l.precoLivro}");
    Console.WriteLine($"AutorID: {l.AutorId}");
    Console.WriteLine($"Apagado? {l.Apagado}");
    Console.WriteLine(new string ('-', 20));
}*/

