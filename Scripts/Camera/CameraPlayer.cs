using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _object; 
    [SerializeField] private Vector3 _distanceFromObject; 
    Event function;
    private void LateUpdate() 
    {
        Vector3 positionToGo = _object.transform.position + _distanceFromObject; 
        Vector3 smoothPosition = Vector3.Lerp(a: transform.position, b: positionToGo, t: 1); 
        transform.position = smoothPosition;
        transform.LookAt(_object.transform.position); 
    }
}
//это не мой скрипт, взял в гугле
