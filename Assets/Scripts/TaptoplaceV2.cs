using UnityEngine;

public class TapToPlace3 : MonoBehaviour
{
    public GameObject objectPrefab; // The prefab to instantiate and place
    public Camera mainCamera; // The main camera
    public float placementOffset = 0.1f; // Offset distance to place the object away from the surface

    private bool isPlacing = false;

    void Update()
    {
        if (isPlacing && Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
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

        // Offset the position to place the object slightly away from the surface
        Vector3 offsetPosition = position + normal * placementOffset;

        GameObject newObject = Instantiate(objectPrefab, offsetPosition, rotation);

        // Tag the new object for deletion
        newObject.tag = "SpawnedObject";
    }
}
