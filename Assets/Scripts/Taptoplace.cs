using UnityEngine;
using MixedReality.Toolkit.Subsystems;
using Microsoft.MixedReality.Toolkit;
using MixedReality.Toolkit.Input;
using MixedReality.Toolkit;


public class TapToPlace : MonoBehaviour
{
    public GameObject objectPrefab;
    public Camera mainCamera; 
    public float placementOffset = 0.1f; 

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
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, normal);

        Vector3 offsetPosition = position + normal * placementOffset;

        GameObject newObject = Instantiate(objectPrefab, offsetPosition, rotation);

        newObject.tag = "SpawnedObject";
    }
}
