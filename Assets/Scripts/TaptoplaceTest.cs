using Microsoft.MixedReality.Toolkit;
using MixedReality.Toolkit;
using MixedReality.Toolkit.Input;
using MixedReality.Toolkit.Subsystems;
using UnityEngine;
using UnityEngine.XR;

public class TapToPlaceTest : MonoBehaviour
{
    public GameObject objectPrefab; // The prefab to instantiate and place
    public Camera mainCamera; // The main camera
    public float placementOffset = 1f; // Offset distance to place the object away from the surface

    private bool isPlacing = false;
    private IHandsAggregatorSubsystem handsAggregatorSubsystem;

    void Start()
    {
        handsAggregatorSubsystem = XRSubsystemHelpers.GetFirstRunningSubsystem<IHandsAggregatorSubsystem>();
        if (handsAggregatorSubsystem == null)
        {
            Debug.LogError("Hands Aggregator Subsystem not found or not running.");
        }
    }

    void Update()
    {
        if (handsAggregatorSubsystem == null)
        {
            Debug.LogError("Hands Aggregator Subsystem is null in Update. Make sure it is properly initialized.");
            return;
        }

        bool isPinchingLeft = false;
        bool isPinchReleasedLeft = false;
        float pinchAmountLeft = 0.0f;

        bool isPinchingRight = false;
        bool isPinchReleasedRight = false;
        float pinchAmountRight = 0.0f;

        try
        {
            if (TryGetPinchProgress(Handedness.Left, out isPinchingLeft, out isPinchReleasedLeft, out pinchAmountLeft) ||
                TryGetPinchProgress(Handedness.Right, out isPinchingRight, out isPinchReleasedRight, out pinchAmountRight))
            {
                bool isPinching = isPinchingLeft || isPinchingRight;
                float pinchAmount = Mathf.Max(pinchAmountLeft, pinchAmountRight);

                if (pinchAmount == 1 && isPlacing)
                {
                    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        PlaceObject(hit.point, hit.normal);
                    }
                    else
                    {
                        Debug.LogError("Raycast did not hit any surface.");
                    }
                }
            }
            else
            {
                Debug.LogError("Failed to get pinch progress.");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Exception in Update: {ex.Message}\n{ex.StackTrace}");
        }
    }

    private bool TryGetPinchProgress(Handedness handedness, out bool isPinching, out bool isPinchReleased, out float pinchAmount)
    {
        isPinching = false;
        isPinchReleased = false;
        pinchAmount = 0.0f;

        if (handsAggregatorSubsystem == null)
        {
            Debug.LogError("Hands Aggregator Subsystem is null in TryGetPinchProgress. Make sure it is properly initialized.");
            return false;
        }

        try
        {
            if (handsAggregatorSubsystem.TryGetPinchProgress((XRNode)handedness, out bool pinchInProgress, out bool pinchReady, out float pinchStrength))
            {
                if (pinchInProgress)
                {
                    isPinching = true;
                    pinchAmount = 1.0f;
                    return true;
                }
                else if (pinchReady && pinchStrength == 0.0f)
                {
                    isPinchReleased = true;
                }
                else
                {
                    Debug.LogError("Pinch progress retrieval failed or pinch not in progress.");
                }
            }
            else
            {
                Debug.LogError($"Failed to retrieve pinch progress for {handedness} hand.");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Exception in TryGetPinchProgress for {handedness} hand: {ex.Message}\n{ex.StackTrace}");
        }
        return false;
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
        // Calculate the rotation to align the object with the normal vector
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, normal);

        // Offset the position to place the object slightly away from the surface
        Vector3 offsetPosition = position + normal * placementOffset;

        GameObject newObject = Instantiate(objectPrefab, offsetPosition, rotation);

        // Tag the new object for deletion
        newObject.tag = "SpawnedObject";
    }
}
