using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Input]
[Unique]
public sealed class TouchPointComponent : IComponent {
    public Vector3 value;
}