using AutoBogus;
using Bogus;
using JornadaMilhas.Dados;
using JornadaMilhas.Test.Integracao.Fixture;
using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test.Integracao;

[Collection(nameof(ContextoCollection))]
public class OfertaViagemDalRecuperaMaiorDesconto
{
    private readonly JornadaMilhasContext context;
    private readonly ContextoFixture fixture;

    public OfertaViagemDalRecuperaMaiorDesconto(ContextoFixture fixture)
    {
        context = fixture.Context;
        this.fixture = fixture;
    }

    [Fact]
    // destino = são paulo, desconto = 40, preco = 80
    public void RetornaOfertaEspecificaQuandoDestinoSaoPauloEDesconto40()
    {
        //arrange
        Rota rota = new AutoFaker<Rota>();
        Periodo periodo = new AutoFaker<Periodo>();
        fixture.CriaDadosFake();

        var ofertaEscolhida = new OfertaViagem(rota, periodo, 80)
        {
            Desconto = 40,
            Ativa = true
        };
        var ofertaInativa = new OfertaViagem(rota, periodo, 70)
        {
            Desconto = 40,
            Ativa = false
        };
        var dal = new OfertaViagemDAL(context);
        dal.Adicionar(ofertaEscolhida);

        context.SaveChanges();
        Func<OfertaViagem, bool> filtro = o => o.Rota.Destino.Equals("São Paulo");
        var precoEsperado = 40;
        //act
        var oferta = dal.RecuperaMaiorDesconto(filtro);
        //assert
        Assert.NotNull(oferta);
        Assert.Equal(precoEsperado, oferta.Preco, 0.0001);
    }
}
