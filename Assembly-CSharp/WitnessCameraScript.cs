using System;
using UnityEngine;

// Token: 0x020004BB RID: 1211
public class WitnessCameraScript : MonoBehaviour
{
	// Token: 0x06001FB2 RID: 8114 RVA: 0x001BF307 File Offset: 0x001BD507
	private void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect(0f, 0f, 0f, 0f);
	}

	// Token: 0x06001FB3 RID: 8115 RVA: 0x001BF33C File Offset: 0x001BD53C
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

	// Token: 0x04004278 RID: 17016
	public YandereScript Yandere;

	// Token: 0x04004279 RID: 17017
	public Transform WitnessPOV;

	// Token: 0x0400427A RID: 17018
	public float WitnessTimer;

	// Token: 0x0400427B RID: 17019
	public Camera MyCamera;

	// Token: 0x0400427C RID: 17020
	public bool Show;
}
