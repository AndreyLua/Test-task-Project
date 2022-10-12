using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private CubeSpawnerParametersHolder _cubeSpawnerParameters;
    
    private float _creationInterval;
    private float _cubeDistance;
    private float _cubeSpeed;
    private float _timer = 0;

    private Vector3 _cubeStartPosition;
    private Queue<GameObject> _inactiveCubes = new Queue<GameObject>();

    private void Awake()
    {
        _cubeStartPosition = gameObject.transform.position;
        _cubeSpawnerParameters.ParametersChanged += UpdateSpawnerParameters;
    }

    private void Update()
    {
        if (_timer <= 0)
        {
            if (_cubeSpeed != 0 && _cubeDistance != 0)
            {
                CreateCube();
                _timer = _creationInterval;
            }
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }

    private void UpdateSpawnerParameters()
    {
        _cubeSpeed = _cubeSpawnerParameters.Speed;
        _creationInterval = _cubeSpawnerParameters.CreationInterval;
        _cubeDistance = _cubeSpawnerParameters.Distance;
    }

    private void CreateCube()
    {
        GameObject cube;
        if (_inactiveCubes.Count > 0)
        {
            cube = _inactiveCubes.Dequeue();
            SetStartCubeParameters(cube);
            cube.SetActive(true);
        }
        else
        {
            cube = Instantiate(_cube, _cubeStartPosition, Quaternion.identity);
            SetStartCubeParameters(cube);
            cube.GetComponent<Cube>().SetParametrs(_cubeSpeed, _cubeDistance);
        }
        cube.GetComponent<Cube>().DistanceCovered += AddCubeInInactiveCubes;
    }

    private void AddCubeInInactiveCubes(GameObject cube)
    {
        cube.GetComponent<Cube>().DistanceCovered -= AddCubeInInactiveCubes;
        _inactiveCubes.Enqueue(cube);
    }

    private void SetStartCubeParameters(GameObject cube)
    {
        cube.transform.position = _cubeStartPosition;
        cube.GetComponent<Cube>().SetParametrs(_cubeSpeed, _cubeDistance);
    }
}
