using UnityEngine;

[RequireComponent(typeof(Transform))]
public class ParentPosition : MonoBehaviour
{
	[SerializeField]
	private Transform ParentTransform;
	[SerializeField]
	private float CustomDistance = 1.0f;

	private Transform ChildTransform;

	private void Awake()
	{
		this.ChildTransform = this.GetComponent<Transform>();
        if (this.ParentTransform == null)
        {
            this.ParentTransform = Camera.main.transform;
        }
    }

	public void MoveToParent()
	{
		if (this.ParentTransform == null || this.ChildTransform == null)
		{
			Debug.LogWarning("Cannot move when transforms are empty");
			return;
		}

		ChildTransform.position = ParentTransform.position;

		Debug.Log($"{ChildTransform}");
	}

	public void MoveInFrontOfParent()
	{
		if (this.ParentTransform == null || this.ChildTransform == null)
		{
			Debug.LogWarning("Cannot move when transforms are empty");
			return;
		}

		Vector3 cameraPosition = Camera.main.transform.position;
		Quaternion cameraRotation = Camera.main.transform.rotation;

		Vector3 spawnPosition = cameraPosition + cameraRotation * Vector3.forward * CustomDistance;

		ChildTransform.position = spawnPosition;

		Debug.Log($"{ChildTransform}");
	}
}
