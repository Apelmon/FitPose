using Entitas;
using Entitas.CodeGeneration.Attributes;

[Ui]
[Event(EventTarget.Self)]
[Event(EventTarget.Self, EventType.Removed)]
public sealed class InteractableComponent : IComponent {
}