using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyTruckRay : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private Ray _rayLeft, _rayRight;
    private RaycastHit _rayHitLeft, _rayHitRight;

    void Update()
    {
        _rayLeft = new Ray(transform.position + new Vector3(0, 1, 5), transform.right);
        _rayRight = new Ray(transform.position + new Vector3(0, 1, 5), -transform.right);

        Debug.DrawRay(transform.position + new Vector3(0, 1, 5), transform.right * 60, Color.red);
        Debug.DrawRay(transform.position + new Vector3(0, 1, 5), -transform.right * 60, Color.red);
        
        if (Physics.Raycast(_rayLeft, out _rayHitLeft))
        {
            if (_rayHitLeft.transform.tag == "Player" && (_player.transform.position - transform.position).sqrMagnitude <= 120 * 120) 
                    _player.GetComponent<PlayerHealth>().AddDamage(500);
        }
        if (Physics.Raycast(_rayRight, out _rayHitRight))
        {
            if (_rayHitRight.transform.tag == "Player" && (_player.transform.position - transform.position).sqrMagnitude <= 120 * 120)
                    _player.GetComponent<PlayerHealth>().AddDamage(500);
        }
    }
}
