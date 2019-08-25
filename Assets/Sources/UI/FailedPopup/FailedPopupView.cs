using System;
using Entitas;
using TMPro;
using UnityEngine;

public class FailedPopupView : PopupConfig {
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _bestScore;
    
    public override void Initialize(Contexts contexts, IEntity entity) {
        base.Initialize(contexts, entity);

        LinkedEntity.isFailedPopup = true;
        
        OnViewEnableRemoved(null);
    }

    public override void OnViewEnable(UiEntity entity) {
        base.OnViewEnable(entity);

        var gsContext = Contexts.sharedInstance.gameState;
        
        if (gsContext.score.value > gsContext.bestScore.value) {
            gsContext.ReplaceBestScore(gsContext.score.value);
            Prefs.SetIntPrefs(Prefs.BEST_SCORE, gsContext.bestScore.value);
        }
        
//        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, Application.version,
//            gsContext.currentLevel.value.ToString("00000"), gsContext.score.value);

        if (_score == null) throw new NullReferenceException("Score text is missing!");
        _score.text = gsContext.score.value.ToString();
        
        if (_bestScore == null) throw new NullReferenceException("Best score text is missing!");
        _bestScore.text = "Best: " + gsContext.bestScore.value.ToString();
    }
}