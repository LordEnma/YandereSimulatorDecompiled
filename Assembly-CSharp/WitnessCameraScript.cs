using System;
using UnityEngine;

// Token: 0x020004CA RID: 1226
public class WitnessCameraScript : MonoBehaviour
{
	// Token: 0x0600200A RID: 8202 RVA: 0x001C6CDF File Offset: 0x001C4EDF
	private void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect(0f, 0f, 0f, 0f);
	}

	// Token: 0x0600200B RID: 8203 RVA: 0x001C6D14 File Offset: 0x001C4F14
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

	// Token: 0x04004372 RID: 17266
	public YandereScript Yandere;

	// Token: 0x04004373 RID: 17267
	public Transform WitnessPOV;

	// Token: 0x04004374 RID: 17268
	public float WitnessTimer;

	// Token: 0x04004375 RID: 17269
	public Camera MyCamera;

	// Token: 0x04004376 RID: 17270
	public bool Show;
}
