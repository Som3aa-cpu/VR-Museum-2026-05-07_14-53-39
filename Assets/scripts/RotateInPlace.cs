using UnityEngine;
 
public class RotateInPlace : MonoBehaviour
{
    [Header("Rotation Settings")]
    [Tooltip("Rotation speed in degrees per second")]
    public float rotationSpeed = 90f;
 
    [Header("Rotation Axis")]
    public bool rotateX = false;
    public bool rotateY = true;
    public bool rotateZ = false;
 
    [Header("Direction")]
    [Tooltip("True = clockwise, False = counter-clockwise")]
    public bool clockwise = true;
 
    void Update()
    {
        float direction = clockwise ? 1f : -1f;
        float angle = rotationSpeed * direction * Time.deltaTime;
 
        Vector3 rotationAxis = new Vector3(
            rotateX ? 1f : 0f,
            rotateY ? 1f : 0f,
            rotateZ ? 1f : 0f
        );
 
        transform.Rotate(rotationAxis * angle, Space.Self);
    }
}