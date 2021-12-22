using System;
using UnityEngine;

// Token: 0x0200036E RID: 878
public class MusicCreditScript : MonoBehaviour
{
	// Token: 0x060019B2 RID: 6578 RVA: 0x001070E0 File Offset: 0x001052E0
	private void Start()
	{
		base.transform.localPosition = new Vector3(400f, base.transform.localPosition.y, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x060019B3 RID: 6579 RVA: 0x00107130 File Offset: 0x00105330
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

	// Token: 0x0400292F RID: 10543
	public UILabel SongLabel;

	// Token: 0x04002930 RID: 10544
	public UILabel BandLabel;

	// Token: 0x04002931 RID: 10545
	public UIPanel Panel;

	// Token: 0x04002932 RID: 10546
	public bool Slide;

	// Token: 0x04002933 RID: 10547
	public float Timer;
}
