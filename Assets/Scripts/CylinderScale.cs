using UnityEngine;

public class ScaleOnInput : MonoBehaviour
{
    private Vector3 initialScale;
    private bool isScaling = false;
    private float scaleFactor = 0.01f; 

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        if (isScaling)
        {
            float scaleChange = Input.GetAxis("Vertical") * scaleFactor;

            Vector3 newScale = initialScale + Vector3.up * scaleChange;

            newScale.y = Mathf.Max(newScale.y, 0.1f);

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
