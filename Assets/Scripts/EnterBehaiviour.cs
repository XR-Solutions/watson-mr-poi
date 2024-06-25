using UnityEngine;
using UnityEngine.UI;

public class EnterKey : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to Text1 Text component.")]
    private Text text1Component;

    public void OnEnterPressed()
    {
        if (text1Component != null)
        {
            // Add logic here for what should happen when Enter is pressed
            Debug.Log("Enter pressed. Current text: " + text1Component.text);
            // For example, you can clear the text
            text1Component.text = "";
        }
    }
}
