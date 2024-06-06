using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaptoplaceV3 : MonoBehaviour
{
    public GameObject objectPrefab; // The prefab to instantiate and place
    public Camera mainCamera; // The main camera
    public GameObject directionPanel; // Reference to the UI panel for direction input
    public TMP_InputField directionInput; // Input field for direction
    public TMP_InputField angleInput; // Input field for angle

    private bool isPlacing = false;
    private GameObject currentObject; // Reference to the object being placed

    void Update()
    {
        if (isPlacing && Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                PlaceObject(hit.point);
            }
        }
    }

    public void StartPlacing()
    {
        isPlacing = true;
        directionPanel.SetActive(false); // Hide direction input panel initially
    }

    public void StopPlacing()
    {
        isPlacing = false;
    }

    private void PlaceObject(Vector3 position)
    {
        currentObject = Instantiate(objectPrefab, position, Quaternion.identity);
        directionPanel.SetActive(true); // Show direction input panel after object is spawned
    }

    public void ConfirmDirectionAndAngle()
    {
        if (currentObject != null)
        {
            string direction = directionInput.text;
            float angle = float.Parse(angleInput.text);

            // Assuming you have a method in your cylinder script to set direction and angle
            //currentObject.GetComponent<CylinderScript>().SetDirectionAndAngle(direction, angle);

            directionPanel.SetActive(false); // Hide direction input panel after confirmation
            currentObject = null; // Reset reference to current object
        }
    }
}
