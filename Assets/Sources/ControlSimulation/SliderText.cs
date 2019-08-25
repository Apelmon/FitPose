using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderText : MonoBehaviour
{
    [SerializeField] private Text _text;

    void Start() {
        _text = GetComponent<Text>();
    }

    public void TextUpdate(float value) {
        _text.text = value.ToString();
    }
}
