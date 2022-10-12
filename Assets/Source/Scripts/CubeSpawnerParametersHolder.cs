using UnityEngine;
using System;

public class CubeSpawnerParametersHolder : MonoBehaviour
{
    [SerializeField] private InputFieldButtons _inputFieldButtons;


    private float _speed;
    private float _distance;
    private float _creationInterval;

    public event Action ParametersChanged;
                        
    public float Speed => _speed;
    public float Distance => _distance;
    public float CreationInterval => _creationInterval;

    private void Awake()
    {
        _inputFieldButtons.CreatinIntervalInputField.EnteredValue += CreationIntervalChange;
        _inputFieldButtons.DistanceInputField.EnteredValue += DistanceChange;
        _inputFieldButtons.SpeedInputField.EnteredValue += SpeedChange;
    }
    private void SpeedChange(float value)
    {
        _speed = value;
        ParametersChanged?.Invoke();
    }
    private void DistanceChange(float value)
    {
        _distance = value;
        ParametersChanged?.Invoke();
    }
    private void CreationIntervalChange(float value)
    {
        _creationInterval = value;
        ParametersChanged?.Invoke();
    }
}
