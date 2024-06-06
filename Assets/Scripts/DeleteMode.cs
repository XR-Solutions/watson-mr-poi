using UnityEngine;

public class DeleteModeManager : MonoBehaviour
{
    public static DeleteModeManager Instance;

    public bool isDeleteModeActive = false;

    void Awake()
    {
        // Ensure there's only one instance of the manager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartDestroying()
    {
        isDeleteModeActive = true;
    }

    public void StopDestroying()
    {
        isDeleteModeActive = false;
    }
}
