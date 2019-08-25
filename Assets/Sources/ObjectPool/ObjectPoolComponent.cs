using DesperateDevs.Utils;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public sealed class ObjectPoolComponent : IComponent {
    [PrimaryEntityIndex] public string id;
    public ObjectPool<IView> value;
}