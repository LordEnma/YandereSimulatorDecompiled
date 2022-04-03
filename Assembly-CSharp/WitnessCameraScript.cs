using System;
using UnityEngine;

// Token: 0x020004C9 RID: 1225
public class WitnessCameraScript : MonoBehaviour
{
	// Token: 0x06002002 RID: 8194 RVA: 0x001C67BF File Offset: 0x001C49BF
	private void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect(0f, 0f, 0f, 0f);
	}

	// Token: 0x06002003 RID: 8195 RVA: 0x001C67F4 File Offset: 0x001C49F4
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

	// Token: 0x0400436E RID: 17262
	public YandereScript Yandere;

	// Token: 0x0400436F RID: 17263
	public Transform WitnessPOV;

	// Token: 0x04004370 RID: 17264
	public float WitnessTimer;

	// Token: 0x04004371 RID: 17265
	public Camera MyCamera;

	// Token: 0x04004372 RID: 17266
	public bool Show;
}
