using JornadaMilhas.Test.Integracao.Fixture;

namespace JornadaMilhas.Test.Integracao;

[CollectionDefinition(nameof(ContextoCollection))]
public class ContextoCollection : ICollectionFixture<ContextoFixture>
{
}
