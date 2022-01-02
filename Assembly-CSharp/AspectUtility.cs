using System;
using UnityEngine;

// Token: 0x020000D6 RID: 214
public class AspectUtility : MonoBehaviour
{
	// Token: 0x060009E5 RID: 2533 RVA: 0x000535CC File Offset: 0x000517CC
	private void Start()
	{
		AspectUtility.cam = base.GetComponent<Camera>();
		if (!AspectUtility.cam)
		{
			AspectUtility.cam = Camera.main;
		}
		if (!AspectUtility.cam)
		{
			Debug.LogError("No camera available");
			return;
		}
		AspectUtility.wantedAspectRatio = this._wantedAspectRatio;
		AspectUtility.SetCamera();
	}

	// Token: 0x060009E6 RID: 2534 RVA: 0x00053624 File Offset: 0x00051824
	public static void SetCamera()
	{
		float num = (float)Screen.width / (float)Screen.height;
		if ((float)((int)(num * 100f)) / 100f == (float)((int)(AspectUtility.wantedAspectRatio * 100f)) / 100f)
		{
			AspectUtility.cam.rect = new Rect(0f, 0f, 1f, 1f);
			if (AspectUtility.backgroundCam)
			{
				UnityEngine.Object.Destroy(AspectUtility.backgroundCam.gameObject);
			}
			return;
		}
		if (num > AspectUtility.wantedAspectRatio)
		{
			float num2 = 1f - AspectUtility.wantedAspectRatio / num;
			AspectUtility.cam.rect = new Rect(num2 / 2f, 0f, 1f - num2, 1f);
		}
		else
		{
			float num3 = 1f - num / AspectUtility.wantedAspectRatio;
			AspectUtility.cam.rect = new Rect(0f, num3 / 2f, 1f, 1f - num3);
		}
		if (!AspectUtility.backgroundCam)
		{
			AspectUtility.backgroundCam = new GameObject("BackgroundCam", new Type[]
			{
				typeof(Camera)
			}).GetComponent<Camera>();
			AspectUtility.backgroundCam.depth = -2.1474836E+09f;
			AspectUtility.backgroundCam.clearFlags = CameraClearFlags.Color;
			AspectUtility.backgroundCam.backgroundColor = Color.black;
			AspectUtility.backgroundCam.cullingMask = 0;
		}
	}

	// Token: 0x170001F6 RID: 502
	// (get) Token: 0x060009E7 RID: 2535 RVA: 0x00053780 File Offset: 0x00051980
	public static int screenHeight
	{
		get
		{
			return (int)((float)Screen.height * AspectUtility.cam.rect.height);
		}
	}

	// Token: 0x170001F7 RID: 503
	// (get) Token: 0x060009E8 RID: 2536 RVA: 0x000537A8 File Offset: 0x000519A8
	public static int screenWidth
	{
		get
		{
			return (int)((float)Screen.width * AspectUtility.cam.rect.width);
		}
	}

	// Token: 0x170001F8 RID: 504
	// (get) Token: 0x060009E9 RID: 2537 RVA: 0x000537D0 File Offset: 0x000519D0
	public static int xOffset
	{
		get
		{
			return (int)((float)Screen.width * AspectUtility.cam.rect.x);
		}
	}

	// Token: 0x170001F9 RID: 505
	// (get) Token: 0x060009EA RID: 2538 RVA: 0x000537F8 File Offset: 0x000519F8
	public static int yOffset
	{
		get
		{
			return (int)((float)Screen.height * AspectUtility.cam.rect.y);
		}
	}

	// Token: 0x170001FA RID: 506
	// (get) Token: 0x060009EB RID: 2539 RVA: 0x00053820 File Offset: 0x00051A20
	public static Rect screenRect
	{
		get
		{
			return new Rect(AspectUtility.cam.rect.x * (float)Screen.width, AspectUtility.cam.rect.y * (float)Screen.height, AspectUtility.cam.rect.width * (float)Screen.width, AspectUtility.cam.rect.height * (float)Screen.height);
		}
	}

	// Token: 0x170001FB RID: 507
	// (get) Token: 0x060009EC RID: 2540 RVA: 0x00053898 File Offset: 0x00051A98
	public static Vector3 mousePosition
	{
		get
		{
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.y -= (float)((int)(AspectUtility.cam.rect.y * (float)Screen.height));
			mousePosition.x -= (float)((int)(AspectUtility.cam.rect.x * (float)Screen.width));
			return mousePosition;
		}
	}

	// Token: 0x170001FC RID: 508
	// (get) Token: 0x060009ED RID: 2541 RVA: 0x000538F8 File Offset: 0x00051AF8
	public static Vector2 guiMousePosition
	{
		get
		{
			Vector2 mousePosition = Event.current.mousePosition;
			mousePosition.y = Mathf.Clamp(mousePosition.y, AspectUtility.cam.rect.y * (float)Screen.height, AspectUtility.cam.rect.y * (float)Screen.height + AspectUtility.cam.rect.height * (float)Screen.height);
			mousePosition.x = Mathf.Clamp(mousePosition.x, AspectUtility.cam.rect.x * (float)Screen.width, AspectUtility.cam.rect.x * (float)Screen.width + AspectUtility.cam.rect.width * (float)Screen.width);
			return mousePosition;
		}
	}

	// Token: 0x04000A86 RID: 2694
	public float _wantedAspectRatio = 1.777778f;

	// Token: 0x04000A87 RID: 2695
	private static float wantedAspectRatio;

	// Token: 0x04000A88 RID: 2696
	private static Camera cam;

	// Token: 0x04000A89 RID: 2697
	private static Camera backgroundCam;
}
