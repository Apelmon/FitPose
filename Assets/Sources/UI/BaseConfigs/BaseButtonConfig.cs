using System;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButtonConfig : UnityUIView {
    protected Button Button;

    public override void Initialize(Contexts contexts, IEntity entity) {
        base.Initialize(contexts, entity);
        
        Button = GetComponent<Button>();
        
        AddListener();
    }

    private void AddListener() {
        if (Button == null) {
            throw new NullReferenceException("Button Component from " + GetType() + " is not found!");
        }
        Button.onClick.AddListener(ButtonHandler);
    }

    protected abstract void ButtonHandler();
}