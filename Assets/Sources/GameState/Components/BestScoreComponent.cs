using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
public sealed class BestScoreComponent : IComponent {
    public int value;
}