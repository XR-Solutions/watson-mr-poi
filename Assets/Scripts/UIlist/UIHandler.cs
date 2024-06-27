using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MixedReality.Toolkit.UX;

public class UIHandler : MonoBehaviour
{
    public OMList OMList; // Reference to the ObjectManager script
    public GameObject buttonPrefab; // Prefab for the button representing each object
    public Transform buttonParent; // Parent transform to hold the buttons

    void Start()
    {
        UpdateObjectList();
    }

    // Method to update the list of objects in the UI
    public void UpdateObjectList()
    {
        // Clear existing buttons
        foreach (Transform child in buttonParent)
        {
            Destroy(child.gameObject);
        }

        // Get the list of created objects
        List<GameObject> createdObjects = OMList.GetCreatedObjects();

        // Create a button for each object
        foreach (GameObject obj in createdObjects)
        {
            GameObject button = Instantiate(buttonPrefab, buttonParent);
            button.GetComponentInChildren<TMP_Text>().text = obj.name;
            button.GetComponent<Button>().onClick.AddListener(() => OnObjectButtonClick(obj));
        }
    }

    // Method called when an object button is clicked
    private void OnObjectButtonClick(GameObject obj)
    {
        OMList.HighlightObject(obj);
    }
}
