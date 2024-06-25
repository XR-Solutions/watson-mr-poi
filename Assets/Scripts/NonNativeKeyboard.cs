using UnityEngine;
using UnityEngine.UI;

namespace MixedReality.Toolkit.UX.Experimental
{
    public class NonNativeKeyboard : MonoBehaviour
    {
        public static NonNativeKeyboard Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void SetTargetInputField(Text target)
        {
            NonNativeValueKey[] keys = GetComponentsInChildren<NonNativeValueKey>();
            foreach (NonNativeValueKey key in keys)
            {
                key.SetTargetInputField(target);
            }
        }
    }
}
