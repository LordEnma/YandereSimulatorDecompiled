using System;
using UnityEngine;

// Token: 0x02000434 RID: 1076
public class SplashCameraScript : MonoBehaviour
{
	// Token: 0x06001CBE RID: 7358 RVA: 0x001540CE File Offset: 0x001522CE
	private void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect(0f, 0.219f, 0f, 0f);
	}

	// Token: 0x06001CBF RID: 7359 RVA: 0x00154100 File Offset: 0x00152300
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

	// Token: 0x040033BA RID: 13242
	public Camera MyCamera;

	// Token: 0x040033BB RID: 13243
	public bool Show;

	// Token: 0x040033BC RID: 13244
	public float Timer;
}
