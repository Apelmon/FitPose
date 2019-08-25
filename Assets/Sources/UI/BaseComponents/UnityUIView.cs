using System;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class UnityUIView : MonoBehaviour, IUIView, IUiDestroyedListener, IUiPositionListener, IAnchorPositionListener {
    public bool Enabled {
        get { return gameObject.activeSelf; }
        set { gameObject.SetActive(value); }
    }

    public virtual Vector3 Position {
        get { return rectTransform.position; }
        set { rectTransform.position = value; }
    }

    public virtual Vector3 Rotation {
        get { return rectTransform.eulerAngles; }
        set { rectTransform.eulerAngles = value; }
    }

    public virtual Vector3 Scale {
        get { return rectTransform.localScale; }
        set { rectTransform.localScale = value; }
    }

    protected UiEntity _linkedEntity;
    private RectTransform _rectTransform;

    public UiEntity LinkedEntity {
        get { return _linkedEntity; }
        set { _linkedEntity = value; }
    }

    public RectTransform rectTransform {
        get => (RectTransform)gameObject.transform;
    }

    public virtual void Initialize(Contexts contexts, IEntity entity) {
        LinkedEntity = (UiEntity)entity;

        Enabled = true;
        gameObject.Link(LinkedEntity);
        
        AddDefaultListeners();

        LinkedEntity.AddUiDestroyedListener(this);
    }

    protected virtual void AddDefaultListeners() {
        if (LinkedEntity.hasPosition) {
            LinkedEntity.AddUiPositionListener(this);
            OnPosition(null, LinkedEntity.position.value);
        }

        if (LinkedEntity.hasAnchorPosition) {
            LinkedEntity.AddAnchorPositionListener(this);
            OnAnchorPosition(null, LinkedEntity.anchorPosition.value);
        }
    }

    public virtual void OnDestroyed(UiEntity entity) {
        Unlink();
        
        if (entity.isPooled) {
            Enabled = false;
            Contexts.sharedInstance.ui
                .GetEntityWithUiObjectPool(name)
                .uiObjectPool.value
                .Push(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy() {
        Unlink();

        Destroy(gameObject);
    }

    private void Unlink() {
        if (gameObject != null && gameObject.GetEntityLink() != null && gameObject.GetEntityLink().entity != null) {
            LinkedEntity.RemoveUiView();
            gameObject.Unlink();
        }
    }
    
    public virtual void OnPosition(UiEntity entity, Vector3 value) {
        rectTransform.position = value;
    }

    public void OnAnchorPosition(UiEntity entity, Vector3 value) {
        rectTransform.anchoredPosition = value;
    }
}