using System;
using UnityEngine;

// Token: 0x020004C1 RID: 1217
public class WitnessCameraScript : MonoBehaviour
{
	// Token: 0x06001FDF RID: 8159 RVA: 0x001C32EB File Offset: 0x001C14EB
	private void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect(0f, 0f, 0f, 0f);
	}

	// Token: 0x06001FE0 RID: 8160 RVA: 0x001C3320 File Offset: 0x001C1520
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

	// Token: 0x040042E2 RID: 17122
	public YandereScript Yandere;

	// Token: 0x040042E3 RID: 17123
	public Transform WitnessPOV;

	// Token: 0x040042E4 RID: 17124
	public float WitnessTimer;

	// Token: 0x040042E5 RID: 17125
	public Camera MyCamera;

	// Token: 0x040042E6 RID: 17126
	public bool Show;
}
