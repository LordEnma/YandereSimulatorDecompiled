using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
	public Camera cameraToLookAt;

	private void Start()
	{
		if (cameraToLookAt == null)
		{
			cameraToLookAt = Camera.main;
		}
	}

	private void Update()
	{
		Vector3 vector = new Vector3(0f, cameraToLookAt.transform.position.y - base.transform.position.y, 0f);
		base.transform.LookAt(cameraToLookAt.transform.position - vector);
	}
}
