using JornadaMilhasV1.Modelos;

namespace UnitTests;

public class OfertaViagemTeste
{
    [Fact]
    public void TestingIfTheOfferIsValid()
    {
        Rota rota = new Rota("OrigemTeste", "DestinoTeste");
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
        double preco = 100.0;
        var validacao = true;

        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        Assert.Equal(validacao, oferta.EhValido);
    }
}