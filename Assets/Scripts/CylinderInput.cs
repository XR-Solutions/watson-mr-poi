using UnityEngine;
using TMPro;
using UnityEngine.UI;
using MixedReality.Toolkit.UX;

public class CylinderInput : MonoBehaviour
{
    public TMP_Text rotationXInput;
    public TMP_Text rotationYInput;

    void Start()
    {
        // Automatically assign the input fields if they are not set in the inspector
        if (rotationXInput == null)
        {
            GameObject XText2 = GameObject.FindWithTag("InputFieldXTag");
            if (XText2 != null)
            {
                rotationXInput = XText2.GetComponent<TMP_Text>();
                if (rotationXInput == null)
                {
                    Debug.LogError("TMP_Text component not found on object with tag 'InputFieldXTag'.");
                }
            }
            else
            {
                Debug.LogError("Object with tag 'InputFieldXTag' not found in the scene.");
            }
        }

        if (rotationYInput == null)
        {
            GameObject YText2 = GameObject.FindWithTag("InputFieldYTag");
            if (YText2 != null)
            {
                rotationYInput = YText2.GetComponent<TMP_Text>();
                if (rotationYInput == null)
                {
                    Debug.LogError("TMP_Text component not found on object with tag 'InputFieldYTag'.");
                }
            }
            else
            {
                Debug.LogError("Object with tag 'InputFieldYTag' not found in the scene.");
            }
        }
    }


    public void ApplyRotation()
    {
        float rotationX = 0;
        float rotationY = 0;

        // Example: Allow input using keyboard
        if (rotationXInput != null)
        {
            float.TryParse(rotationXInput.text, out rotationX);
        }
        else
        {
            Debug.LogError("RotationXInput TMP_Text is null.");
        }

        // Example: Allow input using keyboard
        if (rotationYInput != null)
        {
            float.TryParse(rotationYInput.text, out rotationY);
        }
        else
        {
            Debug.LogError("RotationYInput TMP_Text is null.");
        }

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
    }

}




