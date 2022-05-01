using System;
using UnityEngine;

// Token: 0x02000373 RID: 883
public class MusicCreditScript : MonoBehaviour
{
	// Token: 0x060019E7 RID: 6631 RVA: 0x0010A7AC File Offset: 0x001089AC
	private void Start()
	{
		base.transform.localPosition = new Vector3(400f, base.transform.localPosition.y, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x060019E8 RID: 6632 RVA: 0x0010A7FC File Offset: 0x001089FC
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

	// Token: 0x040029BA RID: 10682
	public UILabel SongLabel;

	// Token: 0x040029BB RID: 10683
	public UILabel BandLabel;

	// Token: 0x040029BC RID: 10684
	public UIPanel Panel;

	// Token: 0x040029BD RID: 10685
	public bool Slide;

	// Token: 0x040029BE RID: 10686
	public float Timer;
}
