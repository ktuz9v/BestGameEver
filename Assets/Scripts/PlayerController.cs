using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _fallVelosity = 0; //гравитация
    private CharacterController _Controller; //называется компонент CharacterController
    private Vector3 _moveForvard; //направление

    public float gravity = 9.8f; //ускорение свободного падения
    public float JumpForse; //сила прыжка
    public float Speed; //скорость персонажа
    void Start()
    {
        _Controller = GetComponent<CharacterController>(); //применяется CharacterController
    }

    void FixedUpdate() //используется ТОЛЬКО для физики
    {
        _Controller.Move(_moveForvard * Speed* Time.fixedDeltaTime); //передвижение

        _fallVelosity += gravity * Time.fixedDeltaTime; //гравитация
        _Controller.Move(Vector3.down * _fallVelosity * Time.deltaTime); //применяется гравитация и прыжок

        if (_Controller.isGrounded) //на земле сила притяжения обнуляется
            _fallVelosity = 0;
    }

    void Update() //используется для логики и нажатия клавиш
    {
        _moveForvard = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) //обозначается направление вперед
            _moveForvard += transform.forward;
        if (Input.GetKey(KeyCode.D)) //обозначается направление вправо
            _moveForvard += transform.right;
        if (Input.GetKey(KeyCode.A)) //обозначается направление Влево
            _moveForvard -= transform.right;
        if (Input.GetKey(KeyCode.S)) //обозначается направление Назад
            _moveForvard -= transform.forward;

        if (Input.GetKeyDown(KeyCode.Space) && _Controller.isGrounded) //прыжок
            _fallVelosity = -JumpForse;
    }
}
