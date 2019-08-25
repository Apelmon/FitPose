using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class CollactableView : UnityView
{
    
    public override void Initialize(Contexts contexts, IEntity entity) {
        base.Initialize(contexts, entity);

        LinkedEntity.isCollactable = true;
        LinkedEntity.isPooled = true;
        
//        var rotDirection = Vector3.up;
//        var speed = Rand.game.Int(50, 100);
//        speed *= (Rand.game.Bool(0.5f)) ? 1 : -1;
//        LinkedEntity.ReplaceIdleRotation(rotDirection, speed);
        
//        if (!LinkedEntity.hasRotation) {
//            LinkedEntity.AddRotation(Vector3.zero);
//            AddDefaultListeners();
//        }
    }

    public override void OnDestroyed(GameEntity entity) {
        // todo create explosion
//        Contexts.sharedInstance.game.DiamondFXExplosion(Position);
        
        base.OnDestroyed(entity);
    }
}
