using System.Collections.Generic;
using UnityEngine;

public class OMList : MonoBehaviour
{
    // List to keep track of created objects
    private List<GameObject> createdObjects = new List<GameObject>();

    // Material to use for highlighting
    public Material highlightMaterial;
    private Material originalMaterial;

    // Method to register a newly created object
    public void RegisterCreatedObject(GameObject newObject)
    {
        createdObjects.Add(newObject);
    }

    // Method to get the list of created objects
    public List<GameObject> GetCreatedObjects()
    {
        return createdObjects;
    }

    // Method to highlight a specific object
    public void HighlightObject(GameObject obj)
    {
        // Reset previous highlight if any
        foreach (var go in createdObjects)
        {
            if (go != obj && go.GetComponent<Renderer>() != null)
            {
                go.GetComponent<Renderer>().material = originalMaterial;
            }
        }

        // Highlight the selected object
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            originalMaterial = renderer.material;
            renderer.material = highlightMaterial;
        }
    }
}
