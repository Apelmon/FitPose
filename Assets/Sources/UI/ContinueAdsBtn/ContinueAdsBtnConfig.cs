using UnityEngine;

public class ContinueAdsBtnConfig : BaseButtonConfig {
    protected override void ButtonHandler() {
        Debug.Log("Initialize ads from " + GetType());
        // todo show ads to user
    }
}