using System;
using DG.Tweening;
using Entitas;
using TMPro;
using UnityEngine;

public class PerfectFXView : UnityUIView, IViewEnableListener, IViewEnableRemovedListener {
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
        
        Rotation = new Vector3(0, 0, Rand.game.Int(-15, 15));

        LinkedEntity.isViewEnable = true;
        
        LinkedEntity.AddViewEnableListener(this);
        LinkedEntity.AddViewEnableRemovedListener(this);
    }

    public void OnViewEnable(UiEntity entity) {
        var delay = 0.2f;
        _text.DOFade(0.0f, 0.3f).SetEase(Ease.OutCirc).From();
        rectTransform.DOScale(Vector3.one * 0.5f, delay).SetEase(Ease.OutBack).From();
        rectTransform.DOAnchorPosY(rectTransform.anchoredPosition.y + 50, delay).SetEase(Ease.OutBack).OnComplete(() => {
            rectTransform.DOAnchorPosY(rectTransform.anchoredPosition.y + 40, 0.5f).SetEase(Ease.Linear).OnComplete(
                () => {
                    LinkedEntity.isViewEnable = false;
                });
        });
    }

    public void OnViewEnableRemoved(UiEntity entity) {
        var delay = 0.3f;
        _text.DOFade(0.0f, 0.5f).SetEase(Ease.OutCirc);
        rectTransform.DOScale(Vector3.one * 1.5f, 0.5f).SetEase(Ease.InSine);
        rectTransform.DOAnchorPosY(rectTransform.anchoredPosition.y + 20, 0.5f).SetEase(Ease.InSine).OnComplete(() => {
            LinkedEntity.isCurrentPerfectFX = false;
            LinkedEntity.isDestroyed = true;
        });
    }
}