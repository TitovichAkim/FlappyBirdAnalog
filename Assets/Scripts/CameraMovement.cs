using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float rotationAngle;
    public void RotateTheCamera ()
    {
        // Поворачиваем камеру на указанный угол
        transform.Rotate(0f, 0f, rotationAngle);
    }
}
