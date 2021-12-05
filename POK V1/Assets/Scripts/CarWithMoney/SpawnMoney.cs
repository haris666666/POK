using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMoney : MonoBehaviour
{
    [SerializeField] private GameObject _money;
    private float _randNumber;
    void Start()
    {
        StartCoroutine(CreateMoney());
        _randNumber = Random.Range(5, 15);
    }

    // Update is called once per frame
    IEnumerator CreateMoney()
    {
        yield return new WaitForSeconds(_randNumber);
        Instantiate(_money, transform.position, Quaternion.identity);
        _randNumber = Random.Range(5, 15);
        StartCoroutine(MoneyCycle());
    }
    IEnumerator MoneyCycle()
    {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(CreateMoney());
    }
}
