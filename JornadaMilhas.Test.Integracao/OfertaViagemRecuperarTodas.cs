using JornadaMilhas.Dados;
using JornadaMilhas.Test.Integracao.Fixture;
using Xunit.Abstractions;

namespace JornadaMilhas.Test.Integracao;

[Collection(nameof(ContextoCollection))]
public class OfertaViagemRecuperarTodas
{
    private readonly JornadaMilhasContext _context;
    public OfertaViagemRecuperarTodas(ITestOutputHelper output, ContextoFixture fix)
    {
        _context = fix.Context;
        output.WriteLine(_context.GetHashCode().ToString());
    }

    [Fact]
    public void DeveRetornarTodos()
    {
        //arrange
        var dal = new OfertaViagemDAL(_context);

        //act
        var recuperarTodas = dal.RecuperarTodas();

        //assert
        Assert.NotNull(recuperarTodas);
    }
}
