using System;
using UnityEngine;

// Token: 0x020004CB RID: 1227
public class WitnessCameraScript : MonoBehaviour
{
	// Token: 0x06002019 RID: 8217 RVA: 0x001C8A77 File Offset: 0x001C6C77
	private void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect(0f, 0f, 0f, 0f);
	}

	// Token: 0x0600201A RID: 8218 RVA: 0x001C8AAC File Offset: 0x001C6CAC
	private void Update()
	{
		if (this.Show)
		{
			this.MyCamera.rect = new Rect(this.MyCamera.rect.x, this.MyCamera.rect.y, Mathf.Lerp(this.MyCamera.rect.width, 0.25f, Time.deltaTime * 10f), Mathf.Lerp(this.MyCamera.rect.height, 0.44444445f, Time.deltaTime * 10f));
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y, base.transform.localPosition.z + Time.deltaTime * 0.09f);
			this.WitnessTimer += Time.deltaTime;
			if (this.WitnessTimer > 5f)
			{
				this.WitnessTimer = 0f;
				this.Show = false;
			}
			if (this.Yandere.Struggling)
			{
				this.WitnessTimer = 0f;
				this.Show = false;
				return;
			}
		}
		else
		{
			this.MyCamera.rect = new Rect(this.MyCamera.rect.x, this.MyCamera.rect.y, Mathf.Lerp(this.MyCamera.rect.width, 0f, Time.deltaTime * 10f), Mathf.Lerp(this.MyCamera.rect.height, 0f, Time.deltaTime * 10f));
			if (this.MyCamera.enabled && this.MyCamera.rect.width < 0.1f)
			{
				this.MyCamera.enabled = false;
				base.transform.parent = null;
			}
		}
	}

	// Token: 0x04004398 RID: 17304
	public YandereScript Yandere;

	// Token: 0x04004399 RID: 17305
	public Transform WitnessPOV;

	// Token: 0x0400439A RID: 17306
	public float WitnessTimer;

	// Token: 0x0400439B RID: 17307
	public Camera MyCamera;

	// Token: 0x0400439C RID: 17308
	public bool Show;
}
