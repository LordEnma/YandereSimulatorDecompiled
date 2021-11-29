using System;
using UnityEngine;

// Token: 0x02000432 RID: 1074
public class SpeedrunTimerScript : MonoBehaviour
{
	// Token: 0x06001CB8 RID: 7352 RVA: 0x00153F73 File Offset: 0x00152173
	private void Start()
	{
		this.Label.enabled = false;
	}

	// Token: 0x06001CB9 RID: 7353 RVA: 0x00153F84 File Offset: 0x00152184
	private void Update()
	{
		if (!this.Police.FadeOut)
		{
			this.Timer += Time.deltaTime;
			if (this.Label.enabled)
			{
				this.Label.text = (this.FormatTime(this.Timer) ?? "");
			}
			if (Input.GetKeyDown(KeyCode.Delete))
			{
				this.Label.enabled = !this.Label.enabled;
			}
		}
	}

	// Token: 0x06001CBA RID: 7354 RVA: 0x00154000 File Offset: 0x00152200
	private string FormatTime(float time)
	{
		int num = (int)time;
		int num2 = num / 60;
		int num3 = num % 60;
		float num4 = time * 1000f;
		num4 %= 1000f;
		return string.Format("{0:00}:{1:00}:{2:000}", num2, num3, num4);
	}

	// Token: 0x040033B1 RID: 13233
	public PoliceScript Police;

	// Token: 0x040033B2 RID: 13234
	public UILabel Label;

	// Token: 0x040033B3 RID: 13235
	public float Timer;
}
