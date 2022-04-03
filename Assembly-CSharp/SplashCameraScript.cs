using System;
using UnityEngine;

// Token: 0x0200043E RID: 1086
public class SplashCameraScript : MonoBehaviour
{
	// Token: 0x06001CFD RID: 7421 RVA: 0x00159CBE File Offset: 0x00157EBE
	private void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect(0f, 0.219f, 0f, 0f);
	}

	// Token: 0x06001CFE RID: 7422 RVA: 0x00159CF0 File Offset: 0x00157EF0
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

	// Token: 0x0400347E RID: 13438
	public Camera MyCamera;

	// Token: 0x0400347F RID: 13439
	public bool Show;

	// Token: 0x04003480 RID: 13440
	public float Timer;
}
