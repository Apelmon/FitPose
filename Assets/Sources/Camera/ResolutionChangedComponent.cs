using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
[Event(EventTarget.Any)]
[Cleanup(CleanupMode.DestroyEntity)]
public sealed class ResolutionChangedComponent : IComponent {
}