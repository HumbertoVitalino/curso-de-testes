using JornadaMilhas.Dados;
using JornadaMilhas.Test.Integracao.Fixture;
using Xunit.Abstractions;

namespace JornadaMilhas.Test.Integracao;

[Collection(nameof(ContextoCollection))]
public class OfertaViagemAdicionar
{
    private readonly JornadaMilhasContext _context;
    private readonly ContextoFixture fix;

    public OfertaViagemAdicionar(ITestOutputHelper output, ContextoFixture fix)
    {
        _context = fix.Context;
        output.WriteLine(_context.GetHashCode().ToString());
        this.fix = fix;
    }

    [Fact]
    public void RegistraOfertaNoBanco()
    {
        //arrange
        var oferta = fix.CriaUmaOfertaValida();
        var dal = new OfertaViagemDAL(_context);

        //act
        dal.Adicionar(oferta);

        //assert
        var ofertaIncluida = dal.RecuperarPorId(oferta.Id);
        Assert.NotNull(ofertaIncluida);
        Assert.Equal(ofertaIncluida.Preco, oferta.Preco, 0.001);
    }

    [Fact]
    public void RegistraOfertaNoBancoComDadosCorretos()
    {
        //arrange
        var oferta = fix.CriaUmaOfertaValida();
        var dal = new OfertaViagemDAL(_context);

        //act
        dal.Adicionar(oferta);

        //assert
        var ofertaIncluida = dal.RecuperarPorId(oferta.Id);
        Assert.NotNull(ofertaIncluida);
        Assert.Equal(ofertaIncluida.Preco, oferta.Preco, 0.001);
        Assert.Equal(ofertaIncluida.Rota, oferta.Rota);
        Assert.Equal(ofertaIncluida.Id, oferta.Id);
        Assert.Equal(ofertaIncluida.Desconto, oferta.Desconto);
    }
}