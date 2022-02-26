using System;
using UnityEngine;

// Token: 0x020004C0 RID: 1216
public class WitnessCameraScript : MonoBehaviour
{
	// Token: 0x06001FD9 RID: 8153 RVA: 0x001C29EF File Offset: 0x001C0BEF
	private void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect(0f, 0f, 0f, 0f);
	}

	// Token: 0x06001FDA RID: 8154 RVA: 0x001C2A24 File Offset: 0x001C0C24
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

	// Token: 0x040042C6 RID: 17094
	public YandereScript Yandere;

	// Token: 0x040042C7 RID: 17095
	public Transform WitnessPOV;

	// Token: 0x040042C8 RID: 17096
	public float WitnessTimer;

	// Token: 0x040042C9 RID: 17097
	public Camera MyCamera;

	// Token: 0x040042CA RID: 17098
	public bool Show;
}
