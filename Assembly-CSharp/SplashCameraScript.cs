using System;
using UnityEngine;

// Token: 0x02000438 RID: 1080
public class SplashCameraScript : MonoBehaviour
{
	// Token: 0x06001CD4 RID: 7380 RVA: 0x00156F1E File Offset: 0x0015511E
	private void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect(0f, 0.219f, 0f, 0f);
	}

	// Token: 0x06001CD5 RID: 7381 RVA: 0x00156F50 File Offset: 0x00155150
	private void Update()
	{
		if (this.Show)
		{
			this.MyCamera.rect = new Rect(this.MyCamera.rect.x, this.MyCamera.rect.y, Mathf.Lerp(this.MyCamera.rect.width, 0.4f, Time.deltaTime * 10f), Mathf.Lerp(this.MyCamera.rect.height, 0.71104f, Time.deltaTime * 10f));
			this.Timer += Time.deltaTime;
			if (this.Timer > 15f)
			{
				this.Show = false;
				this.Timer = 0f;
				return;
			}
		}
		else
		{
			this.MyCamera.rect = new Rect(this.MyCamera.rect.x, this.MyCamera.rect.y, Mathf.Lerp(this.MyCamera.rect.width, 0f, Time.deltaTime * 10f), Mathf.Lerp(this.MyCamera.rect.height, 0f, Time.deltaTime * 10f));
			if (this.MyCamera.enabled && this.MyCamera.rect.width < 0.1f)
			{
				this.MyCamera.enabled = false;
			}
		}
	}

	// Token: 0x04003401 RID: 13313
	public Camera MyCamera;

	// Token: 0x04003402 RID: 13314
	public bool Show;

	// Token: 0x04003403 RID: 13315
	public float Timer;
}
