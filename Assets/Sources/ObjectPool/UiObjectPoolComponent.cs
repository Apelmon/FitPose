using DesperateDevs.Utils;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Ui]
public sealed class UiObjectPoolComponent : IComponent {
    [PrimaryEntityIndex] public string id;
    public ObjectPool<IUIView> value;
}