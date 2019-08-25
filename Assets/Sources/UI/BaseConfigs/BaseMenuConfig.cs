using Entitas;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseMenuConfig : UnityUIView, IViewEnableListener, IViewEnableRemovedListener, IInteractableListener, IInteractableRemovedListener {
    [SerializeField] protected Button[] _buttons;
    [SerializeField] protected float _tweenTime = 0.3f;
    [SerializeField] protected float _hideY = -35;
    [SerializeField] protected float _showY = 35;
    protected bool[] _buttonsInteracteBuffer;

    public override void Initialize(Contexts contexts, IEntity entity) {
        base.Initialize(contexts, entity);
        
        _buttonsInteracteBuffer = new bool[_buttons.Length];

        LinkedEntity.isViewEnable = false;
        LinkedEntity.isInteractable = false;
        OnInteractableRemoved(null);
        
        LinkedEntity.AddViewEnableListener(this);
        LinkedEntity.AddViewEnableRemovedListener(this);
        LinkedEntity.AddInteractableListener(this);
        LinkedEntity.AddInteractableRemovedListener(this);
    }
    
    public virtual void OnViewEnable(UiEntity entity) {
        Enabled = true;
#if UNITY_2018_3
#endif
    }

    public virtual void OnViewEnableRemoved(UiEntity entity) {
        Enabled = false;
#if UNITY_2018_3
#endif
    }

    public virtual void OnInteractable(UiEntity entity) {
        for (int i = 0; i < _buttons.Length; i++) {
            if (_buttons[i] != null) {
                _buttons[i].interactable = _buttonsInteracteBuffer[i];
            }
        }
    }

    public virtual void OnInteractableRemoved(UiEntity entity) {
        for (int i = 0; i < _buttons.Length; i++) {
            if (_buttons[i] != null) {
                _buttonsInteracteBuffer[i] = _buttons[i].interactable;
                _buttons[i].interactable = false;
            }
        }
    }
}