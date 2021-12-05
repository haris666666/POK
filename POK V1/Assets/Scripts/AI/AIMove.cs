using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour
{
    [SerializeField] private WheelCollider _FL, _FR, _RL, _RR; 
    [SerializeField] private GameObject _point1; // Точки, при вхождении в которых, машина поворачивает
    [SerializeField] private GameObject _point2;
    [SerializeField] int _speed;

    private float _rotate = 0.5f;

    void Update()
    {
        _RL.motorTorque = _speed;
        _RR.motorTorque = _speed;

        _FL.steerAngle = _rotate;
        _FR.steerAngle = _rotate;

        _point1.transform.position = new Vector3(_point1.transform.position.x, 
            _point1.transform.position.y, transform.position.z );

        _point2.transform.position = new Vector3(_point2.transform.position.x,
            _point2.transform.position.y, transform.position.z );
    }
    IEnumerator WheelRotate()
    {
        _rotate *= 15;
        yield return new WaitForSeconds(0.2f);
        _rotate /= 15;
    } 
    void OnTriggerEnter(Collider other)
    {
        print(other);
        if(other.transform.tag == "RotateEnemyPointer")
        {
            float _newRotate = -_rotate;
           
            _rotate = _newRotate;
            _rotate = _newRotate;

            StartCoroutine(WheelRotate());

            //print(_rotate);
        }
    }
    public void SetSpeed(int Speed)
    {
        _speed = Speed;
    }
}
