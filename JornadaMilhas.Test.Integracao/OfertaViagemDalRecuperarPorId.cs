using JornadaMilhas.Dados;
using JornadaMilhas.Test.Integracao.Fixture;
using Xunit.Abstractions;

namespace JornadaMilhas.Test.Integracao;

[Collection(nameof(ContextoCollection))]
public class OfertaViagemDalRecuperarPorId
{
    private readonly JornadaMilhasContext _context;
    public OfertaViagemDalRecuperarPorId(ITestOutputHelper output, ContextoFixture fix)
    {
        _context = fix.Context;
        output.WriteLine(_context.GetHashCode().ToString());
    }

    [Fact]
    public void RetornaNuloQuandoInexistente()
    {
        //arrange
        var dal = new OfertaViagemDAL(_context);

        //act
        var ofertaRecuperada = dal.RecuperarPorId(-2);

        //assert
        Assert.Null(ofertaRecuperada);
    }
}
