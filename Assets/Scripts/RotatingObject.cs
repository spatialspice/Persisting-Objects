using UnityEngine;

public class RotatingObject : PersistableObject
{
    [SerializeField] private Vector3 angularVelocity;

    void FixedUpdate()
    {
        transform.Rotate(angularVelocity * Time.deltaTime);
    }
}