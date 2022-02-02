using System;
using UnityEngine;

// Token: 0x0200036F RID: 879
public class MusicCreditScript : MonoBehaviour
{
	// Token: 0x060019B9 RID: 6585 RVA: 0x00107D04 File Offset: 0x00105F04
	private void Start()
	{
		base.transform.localPosition = new Vector3(400f, base.transform.localPosition.y, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x060019BA RID: 6586 RVA: 0x00107D54 File Offset: 0x00105F54
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

	// Token: 0x04002942 RID: 10562
	public UILabel SongLabel;

	// Token: 0x04002943 RID: 10563
	public UILabel BandLabel;

	// Token: 0x04002944 RID: 10564
	public UIPanel Panel;

	// Token: 0x04002945 RID: 10565
	public bool Slide;

	// Token: 0x04002946 RID: 10566
	public float Timer;
}
