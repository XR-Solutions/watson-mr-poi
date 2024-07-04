using UnityEngine;
using MixedReality.Toolkit.Subsystems;
using Microsoft.MixedReality.Toolkit;
using MixedReality.Toolkit.Input;
using MixedReality.Toolkit;
using UnityEditor.SceneManagement;

public class SandD : MonoBehaviour
{
    public GameObject Dot;
    public GameObject Cylinder;
    public Camera mainCamera;
    public float placementOffset = 0.1f;
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

                GameObject newCylinder = Instantiate(Cylinder, dotPosition, dotRotation);
                Destroy(dot);

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
