using UnityEngine;
using MixedReality.Toolkit.Subsystems;
using Microsoft.MixedReality.Toolkit;
using MixedReality.Toolkit.Input;
using MixedReality.Toolkit;
using UnityEditor.SceneManagement;

public class SandD : MonoBehaviour
{
    public GameObject Dot; // The prefab to instantiate and place
    public GameObject Cylinder; // The prefab for the cylinder to instantiate
    public Camera mainCamera; // The main camera
    public float placementOffset = 0.1f; // Offset distance to place the object away from the surface
    private GameObject Spawned;
    public ObjectManager objectManager;

    void Update()
    {
        
    }

    public void SpawnObject()
    {
        GameObject[] activeDots = GameObject.FindGameObjectsWithTag("SpawnedObject");
        if (activeDots.Length > 0)
        {
            Debug.LogWarning("Can't have more than one active dot");

            // Move the existing dot in front of the parent
            GameObject existingDot = activeDots[0];
            ParentPosition parentPosition = existingDot.GetComponent<ParentPosition>();
            if (parentPosition != null)
            {
                parentPosition.MoveInFrontOfParent();
            }
            return;
        }

        Spawned = Instantiate(Dot);
        Spawned.tag = "SpawnedObject";

        ParentPosition newParentPosition = Spawned.GetComponent<ParentPosition>();
        if (newParentPosition != null)
        {
            newParentPosition.MoveInFrontOfParent();
        }
    }

    public void Replace()
    {
        if (Spawned != null)
        {
            GameObject[] activeDots = GameObject.FindGameObjectsWithTag("SpawnedObject");
            if (activeDots.Length > 0)
            {
                GameObject dot = activeDots[0];
                Vector3 dotPosition = dot.transform.position;
                Quaternion dotRotation = dot.transform.rotation;

                // Instantiate the cylinder and destroy the dot
                GameObject newCylinder = Instantiate(Cylinder, dotPosition, dotRotation);
                Destroy(dot);

                // Call ApplyRotation on the CylinderInput component of the new cylinder
                CylinderInput cylinderInput = newCylinder.GetComponent<CylinderInput>();
                if (cylinderInput != null)
                {
                    cylinderInput.ApplyRotation();
                    objectManager.RegisterCreatedObject(newCylinder);
                }
                else
                {
                    Debug.LogError("CylinderInput component not found on the new cylinder.");
                }
            }
        }
    }
}
