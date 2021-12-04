using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [SerializeField] private Text _countMoneyOutput;
    static private int _countMoney;

 
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            Destroy(gameObject);
            _countMoney++;
            _countMoneyOutput.text = _countMoney.ToString();
        }
    }
}
