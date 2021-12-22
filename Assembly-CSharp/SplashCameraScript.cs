using System;
using UnityEngine;

// Token: 0x02000435 RID: 1077
public class SplashCameraScript : MonoBehaviour
{
	// Token: 0x06001CC6 RID: 7366 RVA: 0x001549F2 File Offset: 0x00152BF2
	private void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect(0f, 0.219f, 0f, 0f);
	}

	// Token: 0x06001CC7 RID: 7367 RVA: 0x00154A24 File Offset: 0x00152C24
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

	// Token: 0x040033E5 RID: 13285
	public Camera MyCamera;

	// Token: 0x040033E6 RID: 13286
	public bool Show;

	// Token: 0x040033E7 RID: 13287
	public float Timer;
}
