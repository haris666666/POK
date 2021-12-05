using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRoad : MonoBehaviour
{
    [SerializeField] GameObject _player;
   
    void Update()
    {
        transform.position = new Vector3(0, -4, _player.transform.position.z - 300);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
