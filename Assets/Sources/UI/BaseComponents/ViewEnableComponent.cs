using Entitas;
using Entitas.CodeGeneration.Attributes;

[Ui]
[Event(EventTarget.Self, EventType.Added)]
[Event(EventTarget.Self, EventType.Removed)]
public sealed class ViewEnableComponent : IComponent {
}