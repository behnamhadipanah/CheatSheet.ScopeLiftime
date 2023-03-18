using ScopeLiftime.Logic.Interfaces;

namespace ScopeLiftime.Logic;

public class MyService : IScopedService, ITransientService, ISingletonService
{
    public string InstanceId { get; } = Guid.NewGuid().ToString();

}