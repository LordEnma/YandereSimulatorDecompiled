using UnityEngine;

public class DetectionCameraScript : MonoBehaviour
{
	public Transform YandereChan;

	private void Update()
	{
		base.transform.position = YandereChan.transform.position + Vector3.up * 100f;
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}
}
