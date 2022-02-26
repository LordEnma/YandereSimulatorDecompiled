using System;
using UnityEngine;

// Token: 0x02000438 RID: 1080
public class SpeedrunTimerScript : MonoBehaviour
{
	// Token: 0x06001CDE RID: 7390 RVA: 0x00157B77 File Offset: 0x00155D77
	private void Start()
	{
		this.Label.enabled = false;
	}

	// Token: 0x06001CDF RID: 7391 RVA: 0x00157B88 File Offset: 0x00155D88
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

	// Token: 0x06001CE0 RID: 7392 RVA: 0x00157C04 File Offset: 0x00155E04
	private string FormatTime(float time)
	{
		int num = (int)time;
		int num2 = num / 60;
		int num3 = num % 60;
		float num4 = time * 1000f;
		num4 %= 1000f;
		return string.Format("{0:00}:{1:00}:{2:000}", num2, num3, num4);
	}

	// Token: 0x0400340E RID: 13326
	public PoliceScript Police;

	// Token: 0x0400340F RID: 13327
	public UILabel Label;

	// Token: 0x04003410 RID: 13328
	public float Timer;
}
