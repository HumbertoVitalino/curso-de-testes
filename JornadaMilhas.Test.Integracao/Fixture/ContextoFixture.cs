using JornadaMilhas.Dados;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test.Integracao.Fixture;

public class ContextoFixture
{
    public JornadaMilhasContext Context { get; }
	public ContextoFixture()
	{
        var options = new DbContextOptionsBuilder<JornadaMilhasContext>()
            .UseSqlServer("server = localhost; database= JornadaMilhas; trusted_connection= true, trustservercertificate= true")
            .Options;

        Context = new JornadaMilhasContext(options);
    }
}
