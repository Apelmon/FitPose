using Entitas;
using UnityEngine;

[Game]
public sealed class LayerMaskComponent : IComponent {
    public LayerMask value;
}