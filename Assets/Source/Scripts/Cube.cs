using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _speed;
    private float _distance;
    private Vector3 _offset = new Vector3(1, 0, 0);

    public float Speed => _speed;
    public float Distance => _distance;
    public event Action<GameObject> DistanceCovered;

    public void SetParametrs(float speed, float distance)
    {
        _speed = speed;
        _distance = distance;
    }

    private void Move()
    {
        Vector3 displacement = _speed * Time.deltaTime * _offset;
        transform.position += displacement;
        _distance -= displacement.magnitude;
        if (_distance < 0)
        {
            gameObject.SetActive(false);
            DistanceCovered?.Invoke(gameObject);
        }
    }

    private void Update()
    {
        Move();
    }
}
