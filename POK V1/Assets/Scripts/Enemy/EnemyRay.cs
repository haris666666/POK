using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRay : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private Ray _rayZ, _rayXLeft, _rayXRight;
    private RaycastHit _hitZ, _hitXLeft, _hitXRight;

    void Update()
    {
        _rayZ = new Ray(transform.position, transform.forward);
        _rayXLeft = new Ray(transform.position - new Vector3(0, -1, 8), transform.right);
        _rayXRight = new Ray(transform.position - new Vector3(0, -1, 8), -transform.right);

        Debug.DrawRay(transform.position, transform.forward * 15 , Color.red);
        Debug.DrawRay(transform.position - new Vector3(0, -1, 8), transform.right * 60, Color.red);
        Debug.DrawRay(transform.position - new Vector3(0, -1, 8), -transform.right * 60, Color.red);


        if (Physics.Raycast(_rayZ, out _hitZ))
        {
            if (_hitZ.transform.tag == "Player" && (_player.transform.position - transform.position).sqrMagnitude <= 15 * 15)
            {
                _player.GetComponent<PlayerHealth>().AddDamage(5);
            }
        }
        if (Physics.Raycast(_rayXLeft, out _hitXLeft))
        {
            if (_hitXLeft.transform.tag == "Player" && (_player.transform.position - transform.position).sqrMagnitude <= 120 * 120)
                _player.GetComponent<PlayerHealth>().AddDamage(500);
        }
        if (Physics.Raycast(_rayXRight, out _hitXRight))
        {
            if (_hitXRight.transform.tag == "Player" && (_player.transform.position - transform.position).sqrMagnitude <= 120 * 120) 
                _player.GetComponent<PlayerHealth>().AddDamage(500);
        }
    }
}
