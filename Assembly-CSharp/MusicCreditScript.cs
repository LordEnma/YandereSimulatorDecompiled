using System;
using UnityEngine;

// Token: 0x02000371 RID: 881
public class MusicCreditScript : MonoBehaviour
{
	// Token: 0x060019D3 RID: 6611 RVA: 0x0010982C File Offset: 0x00107A2C
	private void Start()
	{
		base.transform.localPosition = new Vector3(400f, base.transform.localPosition.y, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x060019D4 RID: 6612 RVA: 0x0010987C File Offset: 0x00107A7C
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

	// Token: 0x04002993 RID: 10643
	public UILabel SongLabel;

	// Token: 0x04002994 RID: 10644
	public UILabel BandLabel;

	// Token: 0x04002995 RID: 10645
	public UIPanel Panel;

	// Token: 0x04002996 RID: 10646
	public bool Slide;

	// Token: 0x04002997 RID: 10647
	public float Timer;
}
