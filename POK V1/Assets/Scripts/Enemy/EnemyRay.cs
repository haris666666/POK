using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRay : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private Ray _rayZ, _rayXLeft, _rayXRight;
    private RaycastHit _hitZ, _hitXLeft, _hitXRight;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _rayZ = new Ray(transform.position, transform.right);
        _rayXLeft = new Ray(transform.position, transform.forward);
        _rayXRight = new Ray(transform.position, -transform.forward);

        Debug.DrawRay(transform.position, transform.right * 15, Color.red);
        Debug.DrawRay(transform.position, transform.forward * 15, Color.red);
        Debug.DrawRay(transform.position, -transform.forward * 15, Color.red);


        if (Physics.Raycast(_rayZ, out _hitZ))
        {
            if (_hitZ.transform.tag == "Player" && (_player.transform.position - transform.position).sqrMagnitude <= 15 * 15)
            {
                _player.GetComponent<PlayerHealth>().AddDamage(5);
            }
        }
        if (Physics.Raycast(_rayXLeft, out _hitXLeft))
        {
            if (_hitXLeft.transform.tag == "Player") _player.GetComponent<PlayerHealth>().AddDamage(300);
        }
        if (Physics.Raycast(_rayXRight, out _hitXRight))
        {
            if (_hitXRight.transform.tag == "Player") _player.GetComponent<PlayerHealth>().AddDamage(300);
        }
    }
}
