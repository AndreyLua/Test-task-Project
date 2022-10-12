using UnityEngine;
using TMPro;

public class InputFieldButtons : MonoBehaviour
{
    [SerializeField] private TMP_InputField _speedInputField;
    [SerializeField] private TMP_InputField _distanceInputField;
    [SerializeField] private TMP_InputField _creationIntervalInputField;

    public InputField SpeedInputField => _speedInputField.GetComponent<InputField>();
    public InputField DistanceInputField => _distanceInputField.GetComponent<InputField>();
    public InputField CreatinIntervalInputField => _creationIntervalInputField.GetComponent<InputField>();
}
