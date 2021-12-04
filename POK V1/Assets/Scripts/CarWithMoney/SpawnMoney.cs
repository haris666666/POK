using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMoney : MonoBehaviour
{
    [SerializeField] private GameObject _money;
    void Start()
    {
        StartCoroutine(CreateMoney());
    }

    // Update is called once per frame
    IEnumerator CreateMoney()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(_money, transform.position, Quaternion.identity);
        StartCoroutine(MoneyCycle());
    }
    IEnumerator MoneyCycle()
    {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(CreateMoney());
    }
}
