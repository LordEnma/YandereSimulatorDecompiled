using System;
using UnityEngine;

// Token: 0x0200036D RID: 877
public class MusicCreditScript : MonoBehaviour
{
	// Token: 0x060019AB RID: 6571 RVA: 0x00106840 File Offset: 0x00104A40
	private void Start()
	{
		base.transform.localPosition = new Vector3(400f, base.transform.localPosition.y, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x060019AC RID: 6572 RVA: 0x00106890 File Offset: 0x00104A90
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

	// Token: 0x0400290A RID: 10506
	public UILabel SongLabel;

	// Token: 0x0400290B RID: 10507
	public UILabel BandLabel;

	// Token: 0x0400290C RID: 10508
	public UIPanel Panel;

	// Token: 0x0400290D RID: 10509
	public bool Slide;

	// Token: 0x0400290E RID: 10510
	public float Timer;
}
