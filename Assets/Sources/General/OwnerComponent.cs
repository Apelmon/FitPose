using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public sealed class OwnerComponent : IComponent {
    [PrimaryEntityIndex] public int value;
}