using Entitas;
using UnityEngine;

public class NoAdsBtnConfig : BaseButtonConfig {
    public override void Initialize(Contexts contexts, IEntity entity) {
        base.Initialize(contexts, entity);

        LinkedEntity.isNoAdsBtn = true;
    }

    protected override void ButtonHandler() {
        Debug.Log("Invoke from " + GetType());
        // todo show popup with iap 
    }
}