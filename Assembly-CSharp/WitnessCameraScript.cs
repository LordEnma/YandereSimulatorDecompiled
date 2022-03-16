using System;
using UnityEngine;

// Token: 0x020004C5 RID: 1221
public class WitnessCameraScript : MonoBehaviour
{
	// Token: 0x06001FF5 RID: 8181 RVA: 0x001C5037 File Offset: 0x001C3237
	private void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect(0f, 0f, 0f, 0f);
	}

	// Token: 0x06001FF6 RID: 8182 RVA: 0x001C506C File Offset: 0x001C326C
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

	// Token: 0x0400433D RID: 17213
	public YandereScript Yandere;

	// Token: 0x0400433E RID: 17214
	public Transform WitnessPOV;

	// Token: 0x0400433F RID: 17215
	public float WitnessTimer;

	// Token: 0x04004340 RID: 17216
	public Camera MyCamera;

	// Token: 0x04004341 RID: 17217
	public bool Show;
}
