using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private Text _gameOver;
    [SerializeField] private GameObject _newGameButton;
    [SerializeField] private Image _HP;


    private void Update()
    {
        _HP.fillAmount = _value / 1000;
    }
    public void AddDamage(int Damage)
    {
        _value -= Damage;
        if(_value <= 0)
        {
            print("Game Over");
            transform.GetComponent<PlayerMove>().SetSpeed(0);
            _gameOver.gameObject.SetActive(true);
            _newGameButton.SetActive(true);
        }
    }

    public void NewGameButton()
    {
        Application.LoadLevel("SampleScene");
    }
}
