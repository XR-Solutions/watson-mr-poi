using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private List<GameObject> createdObjects = new List<GameObject>();

    public void RegisterCreatedObject(GameObject newCylinder)
    {
        createdObjects.Add(newCylinder);
    }

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
