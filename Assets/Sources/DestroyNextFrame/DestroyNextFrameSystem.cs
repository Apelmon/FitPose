using System.Collections.Generic;
using Entitas;

public class DestroyNextFrameSystem : ICleanupSystem
{
    private readonly Contexts contexts;

    private readonly IGroup<GameEntity> markedGameEntities;
    private readonly IGroup<UiEntity> markedUiEntities;
    private readonly IGroup<InputEntity> markedInputEntities;

    private readonly List<GameEntity> gameEntityBuffer;
    private readonly List<UiEntity> uiEntityBuffer;
    private readonly List<InputEntity> inputEntityBuffer;

    public DestroyNextFrameSystem(Contexts contexts)
    {
        this.contexts = contexts;

        markedGameEntities = contexts.game.GetGroup(GameMatcher.DestroyNextFrame);
        markedUiEntities = contexts.ui.GetGroup(UiMatcher.DestroyNextFrame);
        markedInputEntities = contexts.input.GetGroup(InputMatcher.DestroyNextFrame);

        gameEntityBuffer = new List<GameEntity>();
        uiEntityBuffer = new List<UiEntity>();
        inputEntityBuffer = new List<InputEntity>();
    }

    public void Cleanup()
    {
        MarkEntities(markedGameEntities, gameEntityBuffer);
        MarkEntities(markedUiEntities, uiEntityBuffer);
        MarkEntities(markedInputEntities, inputEntityBuffer);
    }

    private void MarkEntities<TEntity>(IGroup<TEntity> group, List<TEntity> buffer)
        where TEntity : class, IEntity, IDestroyedEntity, IDestroyNextFrameEntity
    {
        foreach (var e in group.GetEntities(buffer))
        // For each entity in this group...
        {
            e.isDestroyed = true;
            e.willDestroyNextFrame = false;
        }

        buffer.Clear();
    }

}