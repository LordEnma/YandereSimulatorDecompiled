using System;
using UnityEngine;

// Token: 0x02000371 RID: 881
public class MusicCreditScript : MonoBehaviour
{
	// Token: 0x060019CB RID: 6603 RVA: 0x00108E88 File Offset: 0x00107088
	private void Start()
	{
		base.transform.localPosition = new Vector3(400f, base.transform.localPosition.y, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x060019CC RID: 6604 RVA: 0x00108ED8 File Offset: 0x001070D8
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

	// Token: 0x04002971 RID: 10609
	public UILabel SongLabel;

	// Token: 0x04002972 RID: 10610
	public UILabel BandLabel;

	// Token: 0x04002973 RID: 10611
	public UIPanel Panel;

	// Token: 0x04002974 RID: 10612
	public bool Slide;

	// Token: 0x04002975 RID: 10613
	public float Timer;
}
