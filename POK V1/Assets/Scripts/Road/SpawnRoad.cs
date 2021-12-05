using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoad : MonoBehaviour
{
    [SerializeField] GameObject _road;
    private float _spawnPosZ = 15;
    private Vector3 _spawnPos; 
    

    void Start()
    {
        _spawnPos = new Vector3(0, 0, _spawnPosZ);
        StartCoroutine(CreateRoad());
    }

    void Update()
    {
        _spawnPos = new Vector3(0, 0, _spawnPosZ);
    }
    IEnumerator CreateRoad()
    {
        yield return new WaitForSeconds(0.1f);
        _spawnPosZ += 15f;
        Instantiate(_road, _spawnPos, Quaternion.identity);
        StartCoroutine(RoadCycle());
    }
    IEnumerator RoadCycle()
    {
        yield return new WaitForSeconds(0.10f);
        StartCoroutine(CreateRoad());
    }
}
