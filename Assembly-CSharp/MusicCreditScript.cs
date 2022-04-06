using System;
using UnityEngine;

// Token: 0x02000373 RID: 883
public class MusicCreditScript : MonoBehaviour
{
	// Token: 0x060019DF RID: 6623 RVA: 0x00109FE8 File Offset: 0x001081E8
	private void Start()
	{
		base.transform.localPosition = new Vector3(400f, base.transform.localPosition.y, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x060019E0 RID: 6624 RVA: 0x0010A038 File Offset: 0x00108238
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

	// Token: 0x040029A9 RID: 10665
	public UILabel SongLabel;

	// Token: 0x040029AA RID: 10666
	public UILabel BandLabel;

	// Token: 0x040029AB RID: 10667
	public UIPanel Panel;

	// Token: 0x040029AC RID: 10668
	public bool Slide;

	// Token: 0x040029AD RID: 10669
	public float Timer;
}
