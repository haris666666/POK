using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] private int _speed;

    [SerializeField] private WheelCollider _FL;
    [SerializeField] private WheelCollider _FR;
    [SerializeField] private WheelCollider _RL;
    [SerializeField] private WheelCollider _RR;

    [SerializeField] private Image _slider;
    [SerializeField] private GameObject _speedUpButton;
    //private bool _removeSpeed;

    private float _speedUpTimer = 0;



    void Update()
    {
       // print(Mathf.Sign(_joystick.Vertical));

        _RL.motorTorque = _speed;
        _RR.motorTorque = _speed;

        _FL.steerAngle = -_joystick.Vertical * 50;
        _FR.steerAngle = -_joystick.Vertical * 50;

        if(_speedUpTimer < 5)
        {
            _speedUpTimer += Time.deltaTime;
            _speedUpButton.SetActive(false);
            _slider.fillAmount = _speedUpTimer / 5;            
        }


        if (_speedUpTimer > 5) _speedUpTimer = 5;
        if (_speedUpTimer == 5)
        {
            _speedUpButton.SetActive(true);
            _slider.fillAmount = 1;
        }

    }
    
   public void SpeedUp()
   {
        //_removeSpeed = true;
        _speedUpTimer = 0;
        _speed *= 5;

        StartCoroutine(SpeedDown());
   }
    IEnumerator SpeedDown()
    {
        yield return new WaitForSeconds(3);
        _speed /= 5;
    }
    public int GetSpeed()
    {
        return _speed;
    }
}
