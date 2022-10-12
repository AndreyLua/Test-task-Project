using UnityEngine;
using TMPro;
using System;
public class InputField : MonoBehaviour
{
    private TMP_InputField _inputField;
    public event Action<float> EnteredValue;

    private void Awake()
    {
        _inputField = GetComponent<TMP_InputField>();
        _inputField.onValueChanged.AddListener(OnChange);
    }
    public void OnChange(string text)
    {
        if (text.Length > 0 && text.Length < 6)
        {
            if (float.TryParse(text, out float value))
                EnteredValue?.Invoke(value);
            else
                EnteredValue?.Invoke(0);
        }
    }
}
