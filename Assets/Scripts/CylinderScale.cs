using UnityEngine;

public class ScaleOnInput : MonoBehaviour
{
    private Vector3 initialScale;
    private bool isScaling = false;
    private float scaleFactor = 0.01f; // Adjust this value to control the scale change speed

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        if (isScaling)
        {
            // Calculate the scale change based on the input axis (e.g., mouse scroll or touch position)
            float scaleChange = Input.GetAxis("Vertical") * scaleFactor;

            // Calculate the new scale
            Vector3 newScale = initialScale + Vector3.up * scaleChange;

            // Clamp the scale to prevent negative scaling
            newScale.y = Mathf.Max(newScale.y, 0.1f); // Minimum scale to prevent object from disappearing

            // Apply the new scale to the object
            transform.localScale = newScale;
        }
    }

    void OnMouseDown()
    {
        isScaling = true;
    }

    void OnMouseUp()
    {
        isScaling = false;
    }
}
