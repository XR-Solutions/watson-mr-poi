using UnityEngine;
using UnityEngine.UI;

namespace MixedReality.Toolkit.UX.Experimental
{
    public class NonNativeValueKey : NonNativeKey
    {
        private string currentValue;

        public string CurrentValue
        {
            get => currentValue;
            private set
            {
                currentValue = value;
                if (textComponent != null)
                {
                    textComponent.text = currentValue;
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
        private Text textComponent;

        private Text inputFieldTextComponent;

        protected override void Awake()
        {
            base.Awake();
            if (textComponent == null)
            {
                textComponent = GetComponentInChildren<Text>();
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
            if (textComponent == null)
            {
                textComponent = GetComponentInChildren<Text>();
            }
            if (textComponent != null)
            {
                textComponent.text = defaultValue;
            }
        }

        protected override void FireKey()
        {
            InsertValueIntoInputField();
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

        private void InsertValueIntoInputField()
        {
            if (inputFieldTextComponent != null)
            {
                inputFieldTextComponent.text += CurrentValue;
            }
        }

        public void SetTargetInputField(Text target)
        {
            inputFieldTextComponent = target;
        }

        public void PressKey()
        {
            FireKey();
        }
    }
}
