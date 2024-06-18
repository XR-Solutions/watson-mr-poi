using UnityEngine;
using MixedReality.Toolkit.Subsystems;
using Microsoft.MixedReality.Toolkit;
using MixedReality.Toolkit.Input;
using MixedReality.Toolkit;
using UnityEditor.SceneManagement;


public class SandD : MonoBehaviour
{
    public GameObject Dot; // The prefab to instantiate and place
    public GameObject Cylinder;
    public Camera mainCamera; // The main camera
    public float placementOffset = 0.1f; // Offset distance to place the object away from the surface
    private GameObject Spawned;

    private bool isSpawning = false;
    private bool isReplacing = false;


    void Update()
    {
        if (Spawned != null)
        {
            
            if (isReplacing == true)
            {
                Replace();
            }
        }
    
        if ( Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                PlaceObject(hit.point, hit.normal);
            }
        }
    }

   

    public void SpawnObject()
    {
        isSpawning = true;
        Spawned  = Instantiate(Dot) ;
        Spawned.tag = "SpawnedObject";
    }

    public void Replace()
    {
        isReplacing = true;
       
    }


    private void PlaceObject(Vector3 position, Vector3 normal)
    {
        // Calculate the rotation to align the object with the normal vector
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, normal);

        // Offset the position to place the object slightly away from the surface
        Vector3 offsetPosition = position + normal * placementOffset;
    }
}
