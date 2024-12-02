using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests;

public class RotaTeste
{
    [Fact]
    public void TestingIfRoteIsValid()
    {
        //arrange
        Rota rota = new Rota("São Paulo", "Rio de Janeiro");

        //act
        rota.Validar();

        //assert
        Assert.True(rota.EhValido);
    }

    [Fact]
    public void TestIfRouteIsValidWithFirstParameterNull()
    {
        //arrange
        Rota rota = new Rota(null, "Rio de Janeiro");

        //act
        rota.Validar();

        //assert
        Assert.Contains("A rota não pode possuir uma origem nula ou vazia.", rota.Erros.Sumario);
        Assert.False(rota.EhValido);
    }
}
