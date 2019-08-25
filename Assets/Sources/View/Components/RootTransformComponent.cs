using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game]
public sealed class RootTransformComponent : IComponent {
    public Transform value;
}