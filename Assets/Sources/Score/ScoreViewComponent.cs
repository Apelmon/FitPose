using Entitas;
using UnityEngine;

public class ScoreViewComponent : MonoBehaviour, IViewComponent {
    public void Initialize(Contexts contexts, IEntity entity) {
        GameEntity e = (GameEntity)entity;
        e.hasScorePoint = true;
    }
}