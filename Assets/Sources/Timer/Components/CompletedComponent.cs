using Entitas;
using Entitas.CodeGeneration.Attributes;

[Timer]
[Cleanup(CleanupMode.DestroyEntity)]
public sealed class CompletedComponent : IComponent {
}