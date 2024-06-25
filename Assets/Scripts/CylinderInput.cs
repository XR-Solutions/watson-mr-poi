using UnityEngine;
using TMPro;
using UnityEngine.UI;
using MixedReality.Toolkit.UX;

public class CylinderInput : MonoBehaviour
{
    public MRTKUGUIInputField rotationXInput;
    public MRTKUGUIInputField rotationYInput;

    void Awake()
    {
        // Automatically assign the input fields if they are not set in the inspector
        if (rotationXInput == null)
        {
            GameObject inputFieldX = GameObject.FindWithTag("InputFieldXTag");
            if (inputFieldX != null)
            {
                rotationXInput = inputFieldX.GetComponent<MRTKUGUIInputField>();
            }
            else
            {
                Debug.LogError("InputFieldX with tag 'InputFieldXTag' not found in the scene.");
            }
        }

        if (rotationYInput == null)
        {
            GameObject inputFieldY = GameObject.FindWithTag("InputFieldYTag");
            if (inputFieldY != null)
            {
                rotationYInput = inputFieldY.GetComponent<MRTKUGUIInputField>();
            }
            else
            {
                Debug.LogError("InputFieldY with tag 'InputFieldYTag' not found in the scene.");
            }
        }
    }

    public void ApplyRotation()
    {
        float rotationX = 0;
        float rotationY = 0;

        if (rotationXInput != null && float.TryParse(rotationXInput.text, out float x))
        {
            rotationX = x;
        }
        else
        {
            Debug.LogError("rotationXInput is null or invalid.");
        }

        if (rotationYInput != null && float.TryParse(rotationYInput.text, out float y))
        {
            rotationY = y;
        }
        else
        {
            Debug.LogError("rotationYInput is null or invalid.");
        }

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
    }

}
