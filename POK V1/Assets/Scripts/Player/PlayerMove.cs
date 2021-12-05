using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] private int _speed;

    [SerializeField] private WheelCollider _FL, _FR, _RL, _RR;

    [SerializeField] private Image _slider;
    [SerializeField] private GameObject _speedUpButton;

    private float _speedUpTimer = 10;
    private int _primordialSpeed; // изначальная скорость

    private void Start()
    {
        _primordialSpeed = _speed;
    }

    void Update()
    {
       // print(Mathf.Sign(_joystick.Vertical));

        _RL.motorTorque = _speed;
        _RR.motorTorque = _speed;

        if(_speedUpTimer < 10)
        {
            _speedUpTimer += Time.deltaTime;
            _speedUpButton.SetActive(false);
            _slider.fillAmount = _speedUpTimer / 10;            
        }


        if (_speedUpTimer > 10) _speedUpTimer = 10;
        if (_speedUpTimer == 10)
        {
            _speedUpButton.SetActive(true);
            _slider.fillAmount = 1;
        }

        if(transform.rotation.y <= -45 || transform.rotation.y >= 45)
        {
            _FL.steerAngle = 0;
            _FR.steerAngle = 0;
        }

    }
    
   public void SpeedUp()
   {
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
    public void SetSpeed(int Speed)
    {
        _speed = Speed;
    }
    public void ButtonUp()
    {

        _FL.steerAngle = -10;
        _FR.steerAngle = -10;
        
    }
    public void ButtonDown()
    {
        _FL.steerAngle = 10;
        _FR.steerAngle = 10;
    }
    public void ButtonStop()
    {
        _FL.steerAngle = 0;
        _FR.steerAngle = 0;
    }
    public void ButtonBrakeDown()
    {
        _speed = -100;
    }
    public void ButtonBrakeUp()
    {
        _speed = _primordialSpeed;
    }
}
