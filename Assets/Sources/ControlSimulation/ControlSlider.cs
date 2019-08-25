using UnityEngine;
using UnityEngine.UI;

public class ControlSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void Start() {
        _slider = GetComponent<Slider>();

        _slider.onValueChanged.AddListener(ValueChanged);
    }

    private void ValueChanged(float arg0) {
        Contexts.sharedInstance.game.ReplacePoseValue(arg0);
    }
}
