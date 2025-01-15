using AutoBogus;
using JornadaMilhas.Dados;
using JornadaMilhas.Test.Integracao.Fixture;
using JornadaMilhasV1.Modelos;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Test.Integracao;

public class OfertaViagemAdicionar
{
    private readonly JornadaMilhasContext _context;
    private readonly OfertaViagemFixture _fixture;
    public OfertaViagemAdicionar()
    {
        var options = new DbContextOptionsBuilder<JornadaMilhasContext>()
            .UseSqlServer("server = localhost; database= JornadaMilhas; trusted_connection= true, trustservercertificate= true")
            .Options;

        _context = new JornadaMilhasContext(options);
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