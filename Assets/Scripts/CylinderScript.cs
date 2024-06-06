using UnityEngine;

public class CylinderScript : MonoBehaviour
{
    public Vector3 direction; // Direction as a Vector3
    public float angle; // Angle in degrees

    void Start()
    {
        ApplyDirectionAndAngle();
    }

    void OnValidate()
    {
        ApplyDirectionAndAngle();
    }

    private void ApplyDirectionAndAngle()
    {
        // Set the rotation of the cylinder based on the direction and angle
        Quaternion rotation = Quaternion.AngleAxis(angle, direction.normalized);
        transform.rotation = rotation;
    }
}
