using UnityEngine;

public class AudioListenerScript : MonoBehaviour
{
	public Transform Target;

	public Camera mainCamera;

	private void Start()
	{
		mainCamera = Camera.main;
	}

	private void Update()
	{
		base.transform.position = Target.position;
		base.transform.eulerAngles = mainCamera.transform.eulerAngles;
	}
}
