using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CylinderInput : MonoBehaviour
{
    public TMP_InputField rotationXInput; 
    public TMP_InputField rotationYInput; 
    public Button confirmButton; 

    void Start()
    {
        confirmButton.onClick.AddListener(ApplyRotation);
    }

    public void ApplyRotation()
    {
        float rotationX = 0;
        float rotationY = 0;

        if (float.TryParse(rotationXInput.text, out float x))
        {
            rotationX = x;
        }

        if (float.TryParse(rotationYInput.text, out float y))
        {
            rotationY = y;
        }

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
    }
}
