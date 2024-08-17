using UnityEngine;

public class YouTubeFootageCameraScript : MonoBehaviour
{
	public Camera MyCamera;

	public float Rotation;

	public float Target;

	private void Update()
	{
		if (Input.GetButtonDown(InputNames.Xbox_RB))
		{
			MyCamera.enabled = true;
			Time.timeScale = 0.1f;
		}
	}
}
