using System;
using UnityEngine;

// Token: 0x02000441 RID: 1089
public class SplashCameraScript : MonoBehaviour
{
	// Token: 0x06001D16 RID: 7446 RVA: 0x0015BB66 File Offset: 0x00159D66
	private void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect(0f, 0.219f, 0f, 0f);
	}

	// Token: 0x06001D17 RID: 7447 RVA: 0x0015BB98 File Offset: 0x00159D98
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

	// Token: 0x040034B8 RID: 13496
	public Camera MyCamera;

	// Token: 0x040034B9 RID: 13497
	public bool Show;

	// Token: 0x040034BA RID: 13498
	public float Timer;
}
