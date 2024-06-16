using UnityEngine;
using MixedReality.Toolkit.Input;
using MixedReality.Toolkit.Subsystems;
using Microsoft.MixedReality.Toolkit;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class TapToPlaceTest : MonoBehaviour
{
    public GameObject objectPrefab; // The prefab to instantiate and place
    public Camera mainCamera; // The main camera
    public float placementOffset = 0.1f; // Offset distance to place the object away from the surface

    private bool isPlacing = false;
    private HandsSubsystem handSubsystem;

    private void OnEnable()
    {
        var handSubsystems = new List<HandsSubsystem>();
        SubsystemManager.GetSubsystems(handSubsystems);
        if (handSubsystems.Count > 0)
        {
            handSubsystem = handSubsystems[0];
        }

        InputAction pinchAction = new InputAction("Pinch", binding: "<XRController>{LeftHand}/select");
        pinchAction.performed += OnPinchPerformed;
        pinchAction.canceled += OnPinchCanceled;
        pinchAction.Enable();
    }

    private void OnDisable()
    {
        // Clean up the input action bindings
        InputAction pinchAction = new InputAction("Pinch");
        pinchAction.performed -= OnPinchPerformed;
        pinchAction.canceled -= OnPinchCanceled;
        pinchAction.Disable();
    }

    private void OnPinchPerformed(InputAction.CallbackContext context)
    {
        isPlacing = true;
    }

    private void OnPinchCanceled(InputAction.CallbackContext context)
    {
        isPlacing = false;
    }

    void Update()
    {
        if (isPlacing)
        {
            // Cast a ray from the center of the camera view (adjust as needed for your application)
            Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                PlaceObject(hit.point, hit.normal);
            }
        }
    }

    private void PlaceObject(Vector3 position, Vector3 normal)
    {
        // Calculate the rotation to align the object with the normal vector
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, normal);

        // Offset the position to place the object slightly away from the surface
        Vector3 offsetPosition = position + normal * placementOffset;

        GameObject newObject = Instantiate(objectPrefab, offsetPosition, rotation);

        // Tag the new object for deletion
        newObject.tag = "SpawnedObject";
    }
}
