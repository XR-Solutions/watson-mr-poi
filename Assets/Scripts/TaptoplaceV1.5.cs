using UnityEngine;

public class TapToPlace2 : MonoBehaviour
{
    public GameObject objectPrefab; // The prefab to instantiate and place
    public Camera mainCamera; // The main camera

    private bool isPlacing = false;

    void Update()
    {
        if (isPlacing && Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                PlaceObject(hit.point, hit.normal);
            }
        }
    }

    public void StartPlacing()
    {
        isPlacing = true;
    }

    public void StopPlacing()
    {
        isPlacing = false;
    }

    private void PlaceObject(Vector3 position, Vector3 normal)
    {
        // Calculate the rotation to align the object with the normal vector
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, normal);
        Instantiate(objectPrefab, position, rotation);
    }
}
