using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _value;

    public void AddDamage(int Damage)
    {
        _value -= Damage;
        if(_value <= 0)
        {
            print("Game Over");
        }
    }
}
