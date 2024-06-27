using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    // List to keep track of created objects
    private List<GameObject> createdObjects = new List<GameObject>();

    // Method to register a newly created object
    public void RegisterCreatedObject(GameObject newCylinder)
    {
        createdObjects.Add(newCylinder);
    }

    // Method to delete the last created object
    public void DeleteLastCreatedObject()
    {
        if (createdObjects.Count > 0)
        {
            GameObject lastCreatedObject = createdObjects[createdObjects.Count - 1];
            createdObjects.RemoveAt(createdObjects.Count - 1);
            Destroy(lastCreatedObject);
        }
        else
        {
            Debug.LogWarning("No Cylinder to delete.");
        }
    }
}
