using AutoBogus;
using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test.Integracao.Fixture;

public class OfertaViagemFixture
{
    public OfertaViagem CriaUmaOfertaValida()
    {
        Rota rota = new AutoFaker<Rota>();
        Periodo periodo = new AutoFaker<Periodo>();
        double preco = 350;

        return new OfertaViagem(rota, periodo, preco);
    }
}
