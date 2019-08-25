using UnityEngine;

public class SettingsBtnConfig : BaseButtonConfig {
    protected override void ButtonHandler() {
        Debug.Log("Invoke from " + GetType());
        // todo show settings popup 
    }
}