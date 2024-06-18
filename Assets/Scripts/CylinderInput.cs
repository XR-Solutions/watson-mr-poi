using UnityEngine;
using TMPro;
using UnityEngine.UI;
using MixedReality.Toolkit.UX;

public class CylinderInput : MonoBehaviour
{
    public MRTKUGUIInputField rotationXInput; 
    public MRTKUGUIInputField rotationYInput; 
 

    void Start()
    {
        
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
