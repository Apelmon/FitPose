using System;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class UnityView : MonoBehaviour, IView, IGameDestroyedListener, IGamePositionListener, IRotationListener, IScaleListener {
    public bool Enabled {
        get { return gameObject.activeSelf; }
        set { gameObject.SetActive(value); }
    }

    public virtual Vector3 Position {
        get { return gameObject.transform.position; }
        set { gameObject.transform.position = value; }
    }

    public virtual Vector3 Rotation {
        get { return gameObject.transform.eulerAngles; }
        set { gameObject.transform.eulerAngles = value; }
    }

    public virtual Vector3 Scale {
        get { return gameObject.transform.localScale; }
        set { gameObject.transform.localScale = value; }
    }

    protected GameEntity _linkedEntity;
    public GameEntity LinkedEntity {
        get { return _linkedEntity; }
        set { _linkedEntity = value; }
    }

    public virtual void Initialize(Contexts contexts, IEntity entity) {
        LinkedEntity = (GameEntity)entity;

        Enabled = true;
        gameObject.Link(LinkedEntity);

        LinkedEntity.AddGameDestroyedListener(this);
        
        AddDefaultListeners();
    }

    protected void AddDefaultListeners() {
        if (LinkedEntity.hasPosition && !LinkedEntity.hasGamePositionListener) {
            LinkedEntity.AddGamePositionListener(this);
            OnPosition(null, LinkedEntity.position.value);
        }

        if (LinkedEntity.hasRotation && !LinkedEntity.hasRotationListener) {
            LinkedEntity.AddRotationListener(this);
            OnRotation(null, LinkedEntity.rotation.value);
        }

        if (LinkedEntity.hasScale && !LinkedEntity.hasScaleListener) {
            LinkedEntity.AddScaleListener(this);
            OnScale(null, LinkedEntity.scale.value);
        }
    }

    public virtual void OnDestroyed(GameEntity entity) {
        Unlink();
        
        if (entity.isPooled) {
            Enabled = false;
            Contexts.sharedInstance.game
                .GetEntityWithObjectPool(name)
                .objectPool.value
                .Push(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy() {
        if (gameObject != null) {
            Unlink();
            Destroy(gameObject);
        }
    }

    private void Unlink() {
        if (gameObject != null && gameObject.GetEntityLink() != null && gameObject.GetEntityLink().entity != null) {
            // it is a very strange fix
            LinkedEntity.RemoveView();
            gameObject.Unlink();
        }
    }

    public virtual void OnPosition(GameEntity entity, Vector3 value) {
        Position = value;
    }

    public virtual void OnRotation(GameEntity entity, Vector3 value) {
        Rotation = value;
    }

    public virtual void OnScale(GameEntity entity, Vector3 value) {
        Scale = value;
    }
}