using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests;

public class PeriodoTeste
{
    [Fact]
    public void TestingIfPeriodIsValid()
    {
        //arrange
        Periodo periodo = new Periodo(new DateTime(2024, 05, 01), new DateTime(2024, 05, 10));

        //act
        periodo.Validar();

        //assert
        Assert.True(periodo.EhValido);
    }

    [Fact]
    public void TestingIfPeriodIsInvalid()
    {
        //arrange
        Periodo periodo = new Periodo(new DateTime(2024, 05, 12), new DateTime(2024, 05, 10));

        //act
        periodo.Validar();

        //assert
        Assert.Contains("Erro: Data de ida não pode ser maior que a data de volta.", periodo.Erros.Sumario);
        Assert.False(periodo.EhValido);
    }
}
