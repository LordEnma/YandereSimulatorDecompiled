using System;
using UnityEngine;

// Token: 0x02000373 RID: 883
public class MusicCreditScript : MonoBehaviour
{
	// Token: 0x060019E3 RID: 6627 RVA: 0x0010A2AC File Offset: 0x001084AC
	private void Start()
	{
		base.transform.localPosition = new Vector3(400f, base.transform.localPosition.y, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x060019E4 RID: 6628 RVA: 0x0010A2FC File Offset: 0x001084FC
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

	// Token: 0x040029B1 RID: 10673
	public UILabel SongLabel;

	// Token: 0x040029B2 RID: 10674
	public UILabel BandLabel;

	// Token: 0x040029B3 RID: 10675
	public UIPanel Panel;

	// Token: 0x040029B4 RID: 10676
	public bool Slide;

	// Token: 0x040029B5 RID: 10677
	public float Timer;
}
