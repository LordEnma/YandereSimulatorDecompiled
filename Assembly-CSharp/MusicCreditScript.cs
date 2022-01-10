using System;
using UnityEngine;

// Token: 0x0200036F RID: 879
public class MusicCreditScript : MonoBehaviour
{
	// Token: 0x060019B8 RID: 6584 RVA: 0x00107764 File Offset: 0x00105964
	private void Start()
	{
		base.transform.localPosition = new Vector3(400f, base.transform.localPosition.y, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x060019B9 RID: 6585 RVA: 0x001077B4 File Offset: 0x001059B4
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

	// Token: 0x04002939 RID: 10553
	public UILabel SongLabel;

	// Token: 0x0400293A RID: 10554
	public UILabel BandLabel;

	// Token: 0x0400293B RID: 10555
	public UIPanel Panel;

	// Token: 0x0400293C RID: 10556
	public bool Slide;

	// Token: 0x0400293D RID: 10557
	public float Timer;
}
