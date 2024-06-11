using UnityEngine;

public class DeleteMode : MonoBehaviour
{
    private bool isDeleting = false;

    public void StartDeleting()
    {
        isDeleting = true;
    }

    public void StopDeleting()
    {
        isDeleting = false;
    }

    public bool IsDeleting()
    {
        return isDeleting;
    }
}
