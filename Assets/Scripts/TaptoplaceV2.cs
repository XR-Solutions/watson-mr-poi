using UnityEngine;

public class TapToPlace3 : MonoBehaviour
{
    public GameObject objectPrefab; // The prefab to instantiate and place
    public Camera mainCamera; // The main camera

    private bool isPlacing = false;

    void Update()
    {
        if (isPlacing && Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
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
        GameObject newObject = Instantiate(objectPrefab, position, rotation);

        Transform inputFieldsParent = newObject.transform.Find("InputFields");
        if (inputFieldsParent != null)
        {
            inputFieldsParent.gameObject.SetActive(true);
        }

        Transform confirmButton = newObject.transform.Find("Button");
        if (confirmButton != null)
        {
            confirmButton.gameObject.SetActive(true);
        }
    }
}
