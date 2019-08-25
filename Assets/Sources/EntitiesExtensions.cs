using UnityEngine;

public static class EntitiesExtensions {
    public static GameEntity CreateEntityWithView(this GameContext context, string name, Vector3 pos) {
        var e = context.CreateEntity();
        e.AddAsset(name);
        e.AddPosition(pos);

        return e;
    }
}