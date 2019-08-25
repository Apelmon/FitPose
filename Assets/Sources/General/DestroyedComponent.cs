using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Input, Ui]
[Event(EventTarget.Self)]
[Cleanup(CleanupMode.DestroyEntity)]
public sealed class DestroyedComponent : IComponent {
}