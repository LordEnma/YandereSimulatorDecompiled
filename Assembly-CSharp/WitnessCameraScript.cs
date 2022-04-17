using System;
using UnityEngine;

// Token: 0x020004CA RID: 1226
public class WitnessCameraScript : MonoBehaviour
{
	// Token: 0x06002010 RID: 8208 RVA: 0x001C76BB File Offset: 0x001C58BB
	private void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect(0f, 0f, 0f, 0f);
	}

	// Token: 0x06002011 RID: 8209 RVA: 0x001C76F0 File Offset: 0x001C58F0
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

	// Token: 0x04004382 RID: 17282
	public YandereScript Yandere;

	// Token: 0x04004383 RID: 17283
	public Transform WitnessPOV;

	// Token: 0x04004384 RID: 17284
	public float WitnessTimer;

	// Token: 0x04004385 RID: 17285
	public Camera MyCamera;

	// Token: 0x04004386 RID: 17286
	public bool Show;
}
