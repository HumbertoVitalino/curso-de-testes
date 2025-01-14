using AutoBogus;
using JornadaMilhas.Dados;
using JornadaMilhasV1.Modelos;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Test.Integracao;

public class OfertaViagemAdicionar
{
    [Fact]
    public void RegistraOfertaNoBanco()
    {
        //arrange
        Rota rota = new AutoFaker<Rota>();
        Periodo periodo = new AutoFaker<Periodo>();
        double preco = 350;

        var options = new DbContextOptionsBuilder<JornadaMilhasContext>()
            .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JornadaMilhas;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
            .Options;
        var context = new JornadaMilhasContext(options);
        var dal = new OfertaViagemDAL(context);
        var oferta = new OfertaViagem(rota, periodo, preco);

        //act
        dal.Adicionar(oferta);

        //assert
        var ofertaIncluida = dal.RecuperarPorId(oferta.Id);
        Assert.NotNull(ofertaIncluida);
        Assert.Equal(ofertaIncluida.Preco, oferta.Preco, 0.001);
    }
}