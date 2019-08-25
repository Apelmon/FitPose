using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input]
[Cleanup(CleanupMode.DestroyEntity)]
public sealed class CollisionComponent : IComponent {
    public GameEntity self;
    public GameEntity other;
}