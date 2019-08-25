using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Ui]
[Event(EventTarget.Self)]
public sealed class AnchorPositionComponent : IComponent {
    public Vector3 value;
}