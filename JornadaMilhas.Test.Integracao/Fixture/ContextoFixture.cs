using JornadaMilhas.Dados;
using Microsoft.EntityFrameworkCore;
using Testcontainers.MsSql;

namespace JornadaMilhas.Test.Integracao.Fixture;

public class ContextoFixture : IAsyncLifetime
{
    public JornadaMilhasContext Context { get; private set; }
    private readonly MsSqlContainer _container = new MsSqlBuilder()
        .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
        .Build();

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
