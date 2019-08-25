using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Input]
[Unique]
public sealed class PointerPositionComponent : IComponent {
    public Vector3 value;
}