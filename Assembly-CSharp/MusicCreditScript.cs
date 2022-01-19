using System;
using UnityEngine;

// Token: 0x0200036F RID: 879
public class MusicCreditScript : MonoBehaviour
{
	// Token: 0x060019B8 RID: 6584 RVA: 0x001078CC File Offset: 0x00105ACC
	private void Start()
	{
		base.transform.localPosition = new Vector3(400f, base.transform.localPosition.y, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x060019B9 RID: 6585 RVA: 0x0010791C File Offset: 0x00105B1C
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

	// Token: 0x0400293C RID: 10556
	public UILabel SongLabel;

	// Token: 0x0400293D RID: 10557
	public UILabel BandLabel;

	// Token: 0x0400293E RID: 10558
	public UIPanel Panel;

	// Token: 0x0400293F RID: 10559
	public bool Slide;

	// Token: 0x04002940 RID: 10560
	public float Timer;
}
