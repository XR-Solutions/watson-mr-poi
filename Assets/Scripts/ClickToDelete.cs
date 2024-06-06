using UnityEngine;

public class ClickToDelete : MonoBehaviour
{
    void OnMouseDown()
    {
        if (DeleteModeManager.Instance.isDeleteModeActive)
        {
            // Destroy the game object this script is attached to
            Destroy(gameObject);
        }
    }
}
