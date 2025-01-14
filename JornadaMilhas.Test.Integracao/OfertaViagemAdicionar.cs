using AutoBogus;
using JornadaMilhas.Dados;
using JornadaMilhas.Test.Integracao.Fixture;
using JornadaMilhasV1.Modelos;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace JornadaMilhas.Test.Integracao;

public class OfertaViagemAdicionar : IClassFixture<ContextoFixture>
{
    private readonly JornadaMilhasContext _context;
    private readonly OfertaViagemFixture _fixture;
    public OfertaViagemAdicionar(ITestOutputHelper output, ContextoFixture fix)
    {
        _context = fix.Context;   
        output.WriteLine(_context.GetHashCode().ToString());
    }

    [Fact]
    public void RegistraOfertaNoBanco()
    {
        //arrange
        var oferta = _fixture.CriaUmaOfertaValida();
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
        var oferta = _fixture.CriaUmaOfertaValida();
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