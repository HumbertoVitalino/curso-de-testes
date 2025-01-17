using AutoBogus;
using Bogus;
using JornadaMilhas.Dados;
using JornadaMilhasV1.Modelos;
using Microsoft.EntityFrameworkCore;
using Testcontainers.MsSql;

namespace JornadaMilhas.Test.Integracao.Fixture;

public class ContextoFixture : IAsyncLifetime
{
    public JornadaMilhasContext Context { get; private set; }

    private readonly MsSqlContainer _container = new MsSqlBuilder()
        .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
        .Build();

    public OfertaViagem CriaUmaOfertaValida()
    {
        Rota rota = new AutoFaker<Rota>();
        Periodo periodo = new AutoFaker<Periodo>();
        double preco = 350;

        return new OfertaViagem(rota, periodo, preco);
    }

    public void CriaDadosFake()
    {
        var fakerPeriodo = new Faker<Periodo>()
           .CustomInstantiator(f =>
           {
               DateTime dataInicio = f.Date.Soon();
               return new Periodo(dataInicio, dataInicio.AddDays(30));
           });
        var rota = new Rota("Curitiba", "São Paulo");
        var fakerOferta = new Faker<OfertaViagem>()
            .CustomInstantiator(f => new OfertaViagem(
                rota,
                fakerPeriodo.Generate(),
                100 * f.Random.Int(1, 100))
            )
            .RuleFor(o => o.Desconto, f => 40)
            .RuleFor(o => o.Ativa, f => true);

        var lista = fakerOferta.Generate(200);
        Context.OfertasViagem.AddRange(lista);
        Context.SaveChanges();
    }

    public async Task InitializeAsync()
    {
        await _container.StartAsync();
        var options = new DbContextOptionsBuilder<JornadaMilhasContext>()
            .UseSqlServer(_container.GetConnectionString())
            .Options;

        Context = new JornadaMilhasContext(options);
        Context.Database.Migrate();
    }

    public async Task DisposeAsync()
    {
        await _container.StopAsync();
    }
}
