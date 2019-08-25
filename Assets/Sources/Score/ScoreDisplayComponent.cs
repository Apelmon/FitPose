using Entitas;
using Entitas.CodeGeneration.Attributes;

[Ui]
[Event(EventTarget.Self)]
public sealed class ScoreDisplayComponent : IComponent {
    public int value;
}