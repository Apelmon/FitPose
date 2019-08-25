using System;
using DG.Tweening;
using Entitas;
using TMPro;
using UnityEngine;

public class ScoreDisplayView : UnityUIView, IScoreDisplayListener, IViewEnableListener, IViewEnableRemovedListener {
    [SerializeField] private TextMeshProUGUI _text;
    private Vector2 _originalPos = Vector2.one * 1000;

    public override void Initialize(Contexts contexts, IEntity entity) {
        base.Initialize(contexts, entity);

        _text = GetComponent<TextMeshProUGUI>();
        if (_text == null) {
            throw new NullReferenceException("ScoreDisplayView - text is missing!");
        }
        
        Scale = Vector3.one;
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 1.0f);

        if (_originalPos == Vector2.one * 1000) {
            _originalPos = rectTransform.anchoredPosition;
        }
        else {
            rectTransform.anchoredPosition = _originalPos;
        }

        LinkedEntity.isViewEnable = true;
        LinkedEntity.isMainScoreDisplay = true;
        if (!LinkedEntity.hasScoreDisplay) LinkedEntity.ReplaceScoreDisplay(0);
        
        LinkedEntity.AddScoreDisplayListener(this);
        LinkedEntity.AddViewEnableListener(this);
        LinkedEntity.AddViewEnableRemovedListener(this);
    }

    public void OnScoreDisplay(UiEntity entity, int value) {
        var newScale = (Scale.x + 0.1f >= 1.5f) ? Vector3.one * 1.5f : Scale + Vector3.one * 0.1f;
        rectTransform.DOScale(newScale, 0.2f).SetEase(Ease.OutBack);
        _text.text = "+" + (value * 10).ToString();
    }

    public void OnViewEnable(UiEntity entity) {
        _text.DOFade(0.0f, 0.3f).SetEase(Ease.OutCirc).From();
        rectTransform.DOScale(Vector3.one * 0.5f, 0.3f).SetEase(Ease.OutBack).From();
        rectTransform.DOAnchorPosY(rectTransform.anchoredPosition.y + 50, 0.3f).SetEase(Ease.OutBack);
    }

    public void OnViewEnableRemoved(UiEntity entity) {
        LinkedEntity.isMainScoreDisplay = false;
        
        var stateContext = Contexts.sharedInstance.gameState;
        stateContext.ReplaceScore(stateContext.score.value + LinkedEntity.scoreDisplay.value * 10);
        
        _text.DOFade(0.0f, 0.3f).SetEase(Ease.OutCirc);
        rectTransform.DOScale(Vector3.one * 0.5f, 0.3f).SetEase(Ease.InSine);
        rectTransform.DOAnchorPosY(rectTransform.anchoredPosition.y + 100, 0.3f).SetEase(Ease.InSine).OnComplete(() => {
            LinkedEntity.isDestroyed = true;
        });
    }
}