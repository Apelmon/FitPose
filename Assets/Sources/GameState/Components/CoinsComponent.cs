using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
[Event(EventTarget.Any)]
public sealed class CoinsComponent : IComponent {
    public int value;
}