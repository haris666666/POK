using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private int _speed = 5;
    void Start()
    {
        
    }
    void Update()
    {
       // print(_player.GetComponent<Rigidbody>().velocity.magnitude / 5);
        transform.Translate(8 * Time.deltaTime, 0, _speed * Time.deltaTime);

        if (transform.position.x >= -5 || transform.position.x <= -15) _speed = -_speed;
    }
}
