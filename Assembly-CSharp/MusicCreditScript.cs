using System;
using UnityEngine;

// Token: 0x02000372 RID: 882
public class MusicCreditScript : MonoBehaviour
{
	// Token: 0x060019D9 RID: 6617 RVA: 0x00109EE8 File Offset: 0x001080E8
	private void Start()
	{
		base.transform.localPosition = new Vector3(400f, base.transform.localPosition.y, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x060019DA RID: 6618 RVA: 0x00109F38 File Offset: 0x00108138
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

	// Token: 0x040029A6 RID: 10662
	public UILabel SongLabel;

	// Token: 0x040029A7 RID: 10663
	public UILabel BandLabel;

	// Token: 0x040029A8 RID: 10664
	public UIPanel Panel;

	// Token: 0x040029A9 RID: 10665
	public bool Slide;

	// Token: 0x040029AA RID: 10666
	public float Timer;
}
