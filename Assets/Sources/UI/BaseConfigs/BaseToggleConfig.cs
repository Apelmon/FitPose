using System;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseToggleConfig : UnityUIView {
    protected Toggle ToggleBtn;

    private void OnEnable() {
        SetAnimatorParams();
    }

    protected virtual void SetAnimatorParams() {
        
    }

    public override void Initialize(Contexts contexts, IEntity entity) {
        base.Initialize(contexts, entity);

        ToggleBtn = GetComponent<Toggle>();
        
        AddListener();
    }

    private void AddListener() {
        try {
            ToggleBtn.onValueChanged.AddListener(ToggleButtonHandler);
        }
        catch (Exception e) {    
            throw new NullReferenceException("Toggle Component from " + GetType() + " is not found!");
        }
    }

    protected abstract void ToggleButtonHandler(bool value);
}