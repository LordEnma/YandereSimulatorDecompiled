using System;
using UnityEngine;

// Token: 0x02000437 RID: 1079
public class SplashCameraScript : MonoBehaviour
{
	// Token: 0x06001CCF RID: 7375 RVA: 0x0015513A File Offset: 0x0015333A
	private void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect(0f, 0.219f, 0f, 0f);
	}

	// Token: 0x06001CD0 RID: 7376 RVA: 0x0015516C File Offset: 0x0015336C
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

	// Token: 0x040033F2 RID: 13298
	public Camera MyCamera;

	// Token: 0x040033F3 RID: 13299
	public bool Show;

	// Token: 0x040033F4 RID: 13300
	public float Timer;
}
