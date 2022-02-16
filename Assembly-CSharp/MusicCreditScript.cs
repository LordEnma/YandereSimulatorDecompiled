using System;
using UnityEngine;

// Token: 0x02000370 RID: 880
public class MusicCreditScript : MonoBehaviour
{
	// Token: 0x060019C2 RID: 6594 RVA: 0x001081F0 File Offset: 0x001063F0
	private void Start()
	{
		base.transform.localPosition = new Vector3(400f, base.transform.localPosition.y, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x060019C3 RID: 6595 RVA: 0x00108240 File Offset: 0x00106440
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

	// Token: 0x0400294C RID: 10572
	public UILabel SongLabel;

	// Token: 0x0400294D RID: 10573
	public UILabel BandLabel;

	// Token: 0x0400294E RID: 10574
	public UIPanel Panel;

	// Token: 0x0400294F RID: 10575
	public bool Slide;

	// Token: 0x04002950 RID: 10576
	public float Timer;
}
