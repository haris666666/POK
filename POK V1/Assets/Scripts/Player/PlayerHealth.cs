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
    [SerializeField] private GameObject _policeCar;


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
            _policeCar.GetComponent<AIMove>().SetSpeed(-10);
        }
    }

    public void NewGameButton() // для этого нужно было, по моему, отдельный скрипт сделать, но ради 4 строк я не стал этого делать
    {
        Application.LoadLevel("SampleScene");
    }
}
