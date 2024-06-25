using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace MixedReality.Toolkit.UX.Experimental
{
    public class NonNativeKeyboard : MonoBehaviour
    {
        public static NonNativeKeyboard Instance;

        // Add reference to the active input field
        private TMP_InputField activeInputField;

        public UnityEvent<bool> OnKeyboardShifted;

        private void Awake()
        {
            Instance = this;
        }

        // Method to set the active input field
        public void SetActiveInputField(TMP_InputField inputField)
        {
            activeInputField = inputField;
        }

        public void ProcessValueKeyPress(NonNativeValueKey key)
        {
            // Set the target input field for the key
            key.SetTargetInputField(activeInputField);
            // Insert the key value into the active input field
            key.InsertValueIntoInputField();
        }
    }
}
