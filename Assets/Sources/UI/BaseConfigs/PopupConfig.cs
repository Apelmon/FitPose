using System;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.UI;

public class PopupConfig : UnityUIView, IViewEnableListener, IViewEnableRemovedListener {
    [SerializeField] private Button[] _closedButtons;
    
    public override void Initialize(Contexts contexts, IEntity entity) {
        base.Initialize(contexts, entity);

        LinkedEntity.AddViewEnableListener(this);
        LinkedEntity.AddViewEnableRemovedListener(this);
        
        AddListener();
    }

    private void AddListener() {
        foreach (var button in _closedButtons) {
            if (button == null) 
                throw new ArgumentNullException("ClosedButton");
            
            button.onClick.AddListener(ClosedHandler);
        }
    }

    protected virtual void ClosedHandler() {
        LinkedEntity.isViewEnable = false;
    }

    public virtual void OnViewEnable(UiEntity entity) {
        Enabled = true;
    }

    public virtual void OnViewEnableRemoved(UiEntity entity) {
        Enabled = false;
    }
}