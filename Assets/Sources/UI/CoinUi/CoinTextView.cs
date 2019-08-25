using System;
using Entitas;
using TMPro;
using UnityEngine;

public class CoinTextView : UnityUIView, IAnyCoinsListener {
    [SerializeField] private TextMeshProUGUI _text;
    
    public override void Initialize(Contexts contexts, IEntity entity) {
        base.Initialize(contexts, entity);

        _text = GetComponent<TextMeshProUGUI>();
        if (_text == null) {
            throw new ArgumentNullException("CoinTextView -> text is missing!");
        }
        
        contexts.gameState.CreateEntity().AddAnyCoinsListener(this);
    }

    public void OnAnyCoins(GameStateEntity entity, int value) {
        _text.text = value.ToString();
    }
}