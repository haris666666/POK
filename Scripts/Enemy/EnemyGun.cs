using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private int _speed = 30;
    private PlayerHealth _ph;
    void Start()
    {
        _ph = _player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, _speed * Time.deltaTime, 0);
        
        //if (transform.rotation.y >= -30 || transform.rotation.y <= 30) _speed = -_speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _ph.AddDamage(1);
        }
    }

}
