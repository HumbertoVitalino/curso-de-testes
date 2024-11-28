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

    [Fact]
    public void TestingIfTheOfferIsNotValid()
    {
        //arrange
        Rota rota = null;
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
        double preco = 100.0;

        //act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //assert
        Assert.Contains("A oferta de viagem n�o possui rota ou per�odo v�lidos.", oferta.Erros.Sumario);
        Assert.False(oferta.EhValido);
    }
}