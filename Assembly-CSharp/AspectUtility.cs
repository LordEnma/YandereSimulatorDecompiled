using UnityEngine;

public class AspectUtility : MonoBehaviour
{
	public float _wantedAspectRatio = 1.777778f;

	private static float wantedAspectRatio;

	private static Camera cam;

	private static Camera backgroundCam;

	public static int screenHeight => (int)((float)Screen.height * cam.rect.height);

	public static int screenWidth => (int)((float)Screen.width * cam.rect.width);

	public static int xOffset => (int)((float)Screen.width * cam.rect.x);

	public static int yOffset => (int)((float)Screen.height * cam.rect.y);

	public static Rect screenRect => new Rect(cam.rect.x * (float)Screen.width, cam.rect.y * (float)Screen.height, cam.rect.width * (float)Screen.width, cam.rect.height * (float)Screen.height);

	public static Vector3 mousePosition
	{
		get
		{
			Vector3 result = Input.mousePosition;
			result.y -= (int)(cam.rect.y * (float)Screen.height);
			result.x -= (int)(cam.rect.x * (float)Screen.width);
			return result;
		}
	}

	public static Vector2 guiMousePosition
	{
		get
		{
			Vector2 result = Event.current.mousePosition;
			result.y = Mathf.Clamp(result.y, cam.rect.y * (float)Screen.height, cam.rect.y * (float)Screen.height + cam.rect.height * (float)Screen.height);
			result.x = Mathf.Clamp(result.x, cam.rect.x * (float)Screen.width, cam.rect.x * (float)Screen.width + cam.rect.width * (float)Screen.width);
			return result;
		}
	}

	private void Start()
	{
		cam = GetComponent<Camera>();
		if (!cam)
		{
			cam = Camera.main;
		}
		if (!cam)
		{
			Debug.LogError("No camera available");
			return;
		}
		wantedAspectRatio = _wantedAspectRatio;
		SetCamera();
	}

	public static void SetCamera()
	{
		float num = (float)Screen.width / (float)Screen.height;
		if ((float)(int)(num * 100f) / 100f == (float)(int)(wantedAspectRatio * 100f) / 100f)
		{
			cam.rect = new Rect(0f, 0f, 1f, 1f);
			if ((bool)backgroundCam)
			{
				Object.Destroy(backgroundCam.gameObject);
			}
			return;
		}
		if (num > wantedAspectRatio)
		{
			float num2 = 1f - wantedAspectRatio / num;
			cam.rect = new Rect(num2 / 2f, 0f, 1f - num2, 1f);
		}
		else
		{
			float num3 = 1f - num / wantedAspectRatio;
			cam.rect = new Rect(0f, num3 / 2f, 1f, 1f - num3);
		}
		if (!backgroundCam)
		{
			backgroundCam = new GameObject("BackgroundCam", typeof(Camera)).GetComponent<Camera>();
			backgroundCam.depth = -2.1474836E+09f;
			backgroundCam.clearFlags = CameraClearFlags.Color;
			backgroundCam.backgroundColor = Color.black;
			backgroundCam.cullingMask = 0;
		}
	}
}
