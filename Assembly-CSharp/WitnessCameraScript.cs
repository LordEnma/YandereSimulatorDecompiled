using System;
using UnityEngine;

// Token: 0x020004BE RID: 1214
public class WitnessCameraScript : MonoBehaviour
{
	// Token: 0x06001FC2 RID: 8130 RVA: 0x001C0F77 File Offset: 0x001BF177
	private void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect(0f, 0f, 0f, 0f);
	}

	// Token: 0x06001FC3 RID: 8131 RVA: 0x001C0FAC File Offset: 0x001BF1AC
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

	// Token: 0x0400429C RID: 17052
	public YandereScript Yandere;

	// Token: 0x0400429D RID: 17053
	public Transform WitnessPOV;

	// Token: 0x0400429E RID: 17054
	public float WitnessTimer;

	// Token: 0x0400429F RID: 17055
	public Camera MyCamera;

	// Token: 0x040042A0 RID: 17056
	public bool Show;
}
