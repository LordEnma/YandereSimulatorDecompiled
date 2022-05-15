using System;
using UnityEngine;

// Token: 0x020004CC RID: 1228
public class WitnessCameraScript : MonoBehaviour
{
	// Token: 0x06002024 RID: 8228 RVA: 0x001CA0C7 File Offset: 0x001C82C7
	private void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect(0f, 0f, 0f, 0f);
	}

	// Token: 0x06002025 RID: 8229 RVA: 0x001CA0FC File Offset: 0x001C82FC
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

	// Token: 0x040043BE RID: 17342
	public YandereScript Yandere;

	// Token: 0x040043BF RID: 17343
	public Transform WitnessPOV;

	// Token: 0x040043C0 RID: 17344
	public float WitnessTimer;

	// Token: 0x040043C1 RID: 17345
	public Camera MyCamera;

	// Token: 0x040043C2 RID: 17346
	public bool Show;
}
