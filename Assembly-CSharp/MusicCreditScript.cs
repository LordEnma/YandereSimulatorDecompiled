using System;
using UnityEngine;

// Token: 0x0200036E RID: 878
public class MusicCreditScript : MonoBehaviour
{
	// Token: 0x060019B4 RID: 6580 RVA: 0x001073BC File Offset: 0x001055BC
	private void Start()
	{
		base.transform.localPosition = new Vector3(400f, base.transform.localPosition.y, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x060019B5 RID: 6581 RVA: 0x0010740C File Offset: 0x0010560C
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

	// Token: 0x04002933 RID: 10547
	public UILabel SongLabel;

	// Token: 0x04002934 RID: 10548
	public UILabel BandLabel;

	// Token: 0x04002935 RID: 10549
	public UIPanel Panel;

	// Token: 0x04002936 RID: 10550
	public bool Slide;

	// Token: 0x04002937 RID: 10551
	public float Timer;
}
