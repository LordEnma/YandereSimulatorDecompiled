using UnityEngine;

public class GhostScript : MonoBehaviour
{
	public Transform SmartphoneCamera;

	public Transform Neck;

	public Transform GhostEyeLocation;

	public Transform GhostEye;

	public int Frame;

	public bool Move;

	private void Update()
	{
		if (Time.timeScale > 0.0001f)
		{
			if (Frame > 0)
			{
				GetComponent<Animation>().enabled = false;
				base.gameObject.SetActive(value: false);
				Frame = 0;
			}
			Frame++;
		}
	}

	public void Look()
	{
		Neck.LookAt(SmartphoneCamera.position);
	}
}
