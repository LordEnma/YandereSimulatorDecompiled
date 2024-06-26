using UnityEngine;

public class SplashCameraScript : MonoBehaviour
{
	public Camera MyCamera;

	public bool Show;

	public float Timer;

	private void Start()
	{
		MyCamera.enabled = false;
		MyCamera.rect = new Rect(0f, 0.219f, 0f, 0f);
	}

	private void Update()
	{
		if (Show)
		{
			MyCamera.rect = new Rect(MyCamera.rect.x, MyCamera.rect.y, Mathf.Lerp(MyCamera.rect.width, 0.4f, Time.unscaledDeltaTime * 10f), Mathf.Lerp(MyCamera.rect.height, 0.71104f, Time.unscaledDeltaTime * 10f));
			if (Time.timeScale < 0.5f)
			{
				Timer = 15f;
			}
			Timer += Time.unscaledDeltaTime;
			if (Timer > 15f)
			{
				Show = false;
				Timer = 0f;
			}
		}
		else
		{
			MyCamera.rect = new Rect(MyCamera.rect.x, MyCamera.rect.y, Mathf.Lerp(MyCamera.rect.width, 0f, Time.unscaledDeltaTime * 10f), Mathf.Lerp(MyCamera.rect.height, 0f, Time.unscaledDeltaTime * 10f));
			if (MyCamera.enabled && MyCamera.rect.width < 0.1f)
			{
				MyCamera.enabled = false;
			}
		}
	}
}
