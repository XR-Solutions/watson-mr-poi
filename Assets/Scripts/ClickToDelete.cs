using UnityEngine;

public class ClickToDelete : MonoBehaviour
{
    private DeleteMode deleteMode;

    void Start()
    {
        deleteMode = FindObjectOfType<DeleteMode>();
    }

    void Update()
    {
        if (deleteMode != null && deleteMode.IsDeleting() && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject target = hit.collider.gameObject;

                if (target.CompareTag("SpawnedObject") || target.transform.root.CompareTag("SpawnedObject"))
                {
                    Destroy(target.transform.root.gameObject);
                }
            }
        }
    }
}
