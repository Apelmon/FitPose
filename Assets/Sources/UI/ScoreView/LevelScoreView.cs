using System;
using Entitas;
using TMPro;
using UnityEngine;

public class LevelScoreView : UnityUIView, IAnyScoreListener {
    [SerializeField] private TextMeshProUGUI _text;
    
    public override void Initialize(Contexts contexts, IEntity entity) {
        base.Initialize(contexts, entity);

        _text = GetComponent<TextMeshProUGUI>();
        if (_text == null) {
            throw new NullReferenceException("LevelScoreView - text missing!");
        }
        
        contexts.gameState.CreateEntity().AddAnyScoreListener(this);
    }

    public void OnAnyScore(GameStateEntity entity, int value) {
        _text.text = value.ToString();
    }
}