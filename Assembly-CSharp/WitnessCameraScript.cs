using System;
using UnityEngine;

// Token: 0x020004BF RID: 1215
public class WitnessCameraScript : MonoBehaviour
{
	// Token: 0x06001FD0 RID: 8144 RVA: 0x001C1E63 File Offset: 0x001C0063
	private void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect(0f, 0f, 0f, 0f);
	}

	// Token: 0x06001FD1 RID: 8145 RVA: 0x001C1E98 File Offset: 0x001C0098
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

	// Token: 0x040042B6 RID: 17078
	public YandereScript Yandere;

	// Token: 0x040042B7 RID: 17079
	public Transform WitnessPOV;

	// Token: 0x040042B8 RID: 17080
	public float WitnessTimer;

	// Token: 0x040042B9 RID: 17081
	public Camera MyCamera;

	// Token: 0x040042BA RID: 17082
	public bool Show;
}
