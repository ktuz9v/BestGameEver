using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float RotationSpeed = 5; //чуствительность мышки
    public Transform CameraAxisTransform; //обозначение объекта для того, чтобы вращать камеру по у

    public float minAngle; //мин угол наклона по у
    public float maxAngle; //макс угол наклона по у

    void Update()
    {
        var newAngleY = transform.localEulerAngles.y + Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(0, newAngleY, 0); //вращение камеры по х

        var newAngleX = CameraAxisTransform.localEulerAngles.x + Time.deltaTime * -RotationSpeed * Input.GetAxis("Mouse Y");
        if (newAngleX > 180)
            newAngleX -= 360;
        newAngleX = Mathf.Clamp(newAngleX, minAngle, maxAngle);
        CameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0); //вращение камеры по у
    }
}
