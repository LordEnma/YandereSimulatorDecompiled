using System;
using UnityEngine;

// Token: 0x020004CC RID: 1228
public class WitnessCameraScript : MonoBehaviour
{
	// Token: 0x06002025 RID: 8229 RVA: 0x001CA5DB File Offset: 0x001C87DB
	private void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect(0f, 0f, 0f, 0f);
	}

	// Token: 0x06002026 RID: 8230 RVA: 0x001CA610 File Offset: 0x001C8810
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

	// Token: 0x040043C7 RID: 17351
	public YandereScript Yandere;

	// Token: 0x040043C8 RID: 17352
	public Transform WitnessPOV;

	// Token: 0x040043C9 RID: 17353
	public float WitnessTimer;

	// Token: 0x040043CA RID: 17354
	public Camera MyCamera;

	// Token: 0x040043CB RID: 17355
	public bool Show;
}
