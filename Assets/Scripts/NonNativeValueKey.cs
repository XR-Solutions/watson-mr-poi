using TMPro;
using UnityEngine;

namespace MixedReality.Toolkit.UX.Experimental
{
    public class NonNativeValueKey : NonNativeKey
    {
        private string currentValue;

        // Add reference to the active input field
        private TMP_InputField targetInputField;

        public string CurrentValue
        {
            get => currentValue;
            private set
            {
                currentValue = value;
                if (textMeshProText != null)
                {
                    textMeshProText.text = currentValue;
                }
            }
        }

        [SerializeField, Tooltip("The default string value for this key.")]
        private string defaultValue;

        public string DefaultValue
        {
            get => defaultValue;
            set => defaultValue = value;
        }

        [SerializeField, Tooltip("The shifted string value for this key.")]
        private string shiftedValue = null;

        public string ShiftedValue
        {
            get => shiftedValue;
            set => shiftedValue = value;
        }

        [SerializeField, Tooltip("Reference to child text element.")]
        private TMP_Text textMeshProText;

        protected override void Awake()
        {
            base.Awake();
            if (textMeshProText == null)
            {
                textMeshProText = GetComponentInChildren<TMP_Text>();
            }

            CurrentValue = defaultValue;

            if (string.IsNullOrEmpty(shiftedValue))
            {
                shiftedValue = defaultValue;
            }
        }

        private void Start()
        {
            NonNativeKeyboard.Instance?.OnKeyboardShifted?.AddListener(Shift);
        }

        private void OnValidate()
        {
            if (textMeshProText == null)
            {
                textMeshProText = GetComponentInChildren<TMP_Text>();
            }
            if (textMeshProText != null)
            {
                textMeshProText.text = defaultValue;
            }
        }

        protected override void FireKey()
        {
            NonNativeKeyboard.Instance.ProcessValueKeyPress(this);
        }

        private void Shift(bool isShifted)
        {
            if (isShifted)
            {
                CurrentValue = shiftedValue;
            }
            else
            {
                CurrentValue = defaultValue;
            }
        }

        // Method to set the target input field
        public void SetTargetInputField(TMP_InputField inputField)
        {
            targetInputField = inputField;
        }

        // Method to insert the key value into the active input field
        public void InsertValueIntoInputField()
        {
            if (targetInputField != null)
            {
                targetInputField.text += CurrentValue;
            }
        }
    }
}
