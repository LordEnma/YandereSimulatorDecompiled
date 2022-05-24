using System;
using UnityEngine;

// Token: 0x02000374 RID: 884
public class MusicCreditScript : MonoBehaviour
{
	// Token: 0x060019EE RID: 6638 RVA: 0x0010B1FC File Offset: 0x001093FC
	private void Start()
	{
		base.transform.localPosition = new Vector3(400f, base.transform.localPosition.y, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x060019EF RID: 6639 RVA: 0x0010B24C File Offset: 0x0010944C
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

	// Token: 0x040029D3 RID: 10707
	public UILabel SongLabel;

	// Token: 0x040029D4 RID: 10708
	public UILabel BandLabel;

	// Token: 0x040029D5 RID: 10709
	public UIPanel Panel;

	// Token: 0x040029D6 RID: 10710
	public bool Slide;

	// Token: 0x040029D7 RID: 10711
	public float Timer;
}
