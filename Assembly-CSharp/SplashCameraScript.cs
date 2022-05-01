using System;
using UnityEngine;

// Token: 0x02000440 RID: 1088
public class SplashCameraScript : MonoBehaviour
{
	// Token: 0x06001D0F RID: 7439 RVA: 0x0015AC2A File Offset: 0x00158E2A
	private void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect(0f, 0.219f, 0f, 0f);
	}

	// Token: 0x06001D10 RID: 7440 RVA: 0x0015AC5C File Offset: 0x00158E5C
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

	// Token: 0x0400349B RID: 13467
	public Camera MyCamera;

	// Token: 0x0400349C RID: 13468
	public bool Show;

	// Token: 0x0400349D RID: 13469
	public float Timer;
}
