using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour
{
    //[SerializeField] private GameObject _player;
    private int _speed = 5;
    void Update()
    {
        transform.Translate(8 * Time.deltaTime, 0, _speed * Time.deltaTime);

        if (transform.position.x >= -6 || transform.position.x <= -14) _speed = -_speed;
    }
}
