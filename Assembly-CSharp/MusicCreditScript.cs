using System;
using UnityEngine;

// Token: 0x0200036F RID: 879
public class MusicCreditScript : MonoBehaviour
{
	// Token: 0x060019BB RID: 6587 RVA: 0x00107ECC File Offset: 0x001060CC
	private void Start()
	{
		base.transform.localPosition = new Vector3(400f, base.transform.localPosition.y, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x060019BC RID: 6588 RVA: 0x00107F1C File Offset: 0x0010611C
	private void Update()
	{
		if (this.Slide)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer < 5f)
			{
				base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
				return;
			}
			base.transform.localPosition = new Vector3(base.transform.localPosition.x + Time.deltaTime, base.transform.localPosition.y, base.transform.localPosition.z);
			base.transform.localPosition = new Vector3(base.transform.localPosition.x + Mathf.Abs(base.transform.localPosition.x * 0.01f) * (Time.deltaTime * 1000f), base.transform.localPosition.y, base.transform.localPosition.z);
			if (base.transform.localPosition.x > 400f)
			{
				base.transform.localPosition = new Vector3(400f, base.transform.localPosition.y, base.transform.localPosition.z);
				this.Panel.enabled = false;
				this.Slide = false;
				this.Timer = 0f;
			}
		}
	}

	// Token: 0x04002946 RID: 10566
	public UILabel SongLabel;

	// Token: 0x04002947 RID: 10567
	public UILabel BandLabel;

	// Token: 0x04002948 RID: 10568
	public UIPanel Panel;

	// Token: 0x04002949 RID: 10569
	public bool Slide;

	// Token: 0x0400294A RID: 10570
	public float Timer;
}
