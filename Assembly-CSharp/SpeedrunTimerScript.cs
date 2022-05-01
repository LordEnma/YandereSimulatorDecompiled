using System;
using UnityEngine;

// Token: 0x0200043E RID: 1086
public class SpeedrunTimerScript : MonoBehaviour
{
	// Token: 0x06001D09 RID: 7433 RVA: 0x0015AACF File Offset: 0x00158CCF
	private void Start()
	{
		this.Label.enabled = false;
	}

	// Token: 0x06001D0A RID: 7434 RVA: 0x0015AAE0 File Offset: 0x00158CE0
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

	// Token: 0x06001D0B RID: 7435 RVA: 0x0015AB5C File Offset: 0x00158D5C
	private string FormatTime(float time)
	{
		int num = (int)time;
		int num2 = num / 60;
		int num3 = num % 60;
		float num4 = time * 1000f;
		num4 %= 1000f;
		return string.Format("{0:00}:{1:00}:{2:000}", num2, num3, num4);
	}

	// Token: 0x04003492 RID: 13458
	public PoliceScript Police;

	// Token: 0x04003493 RID: 13459
	public UILabel Label;

	// Token: 0x04003494 RID: 13460
	public float Timer;
}
