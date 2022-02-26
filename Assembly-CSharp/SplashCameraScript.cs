using System;
using UnityEngine;

// Token: 0x0200043A RID: 1082
public class SplashCameraScript : MonoBehaviour
{
	// Token: 0x06001CE4 RID: 7396 RVA: 0x00157CD2 File Offset: 0x00155ED2
	private void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect(0f, 0.219f, 0f, 0f);
	}

	// Token: 0x06001CE5 RID: 7397 RVA: 0x00157D04 File Offset: 0x00155F04
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

	// Token: 0x04003417 RID: 13335
	public Camera MyCamera;

	// Token: 0x04003418 RID: 13336
	public bool Show;

	// Token: 0x04003419 RID: 13337
	public float Timer;
}
