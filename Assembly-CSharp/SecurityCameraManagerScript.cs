using UnityEngine;

public class SecurityCameraManagerScript : MonoBehaviour
{
	public GameObject[] Cameras;

	private void Start()
	{
		int num = 0;
		for (num = ((!SchoolGlobals.HighSecurity) ? PlayerGlobals.CorpsesDiscovered : Cameras.Length); num > 0; num--)
		{
			if (num < Cameras.Length)
			{
				Cameras[num].SetActive(value: true);
			}
		}
	}

	public void ActivateAllCameras()
	{
		for (int num = Cameras.Length; num > 0; num--)
		{
			if (num < Cameras.Length)
			{
				Cameras[num].SetActive(value: true);
			}
		}
	}
}
