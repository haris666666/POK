using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyTruckRay : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private Ray _rayLeft, _rayRight;
    private RaycastHit _rayHitLeft, _rayHitRight;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _rayLeft = new Ray(transform.position, transform.forward);
        _rayRight = new Ray(transform.position, -transform.forward);

        Debug.DrawRay(transform.position, transform.forward * 15, Color.red);
        Debug.DrawRay(transform.position, -transform.forward * 15, Color.red);

        if (Physics.Raycast(_rayLeft, out _rayHitLeft))
        {
            if (_rayHitLeft.transform.tag == "Player") _player.GetComponent<PlayerHealth>().AddDamage(100);
        }
        if (Physics.Raycast(_rayRight, out _rayHitRight))
        {
            if (_rayHitRight.transform.tag == "Player") _player.GetComponent<PlayerHealth>().AddDamage(100);
        }
    }
}
