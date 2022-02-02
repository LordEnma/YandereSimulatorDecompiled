using System;
using UnityEngine;

// Token: 0x02000436 RID: 1078
public class SpeedrunTimerScript : MonoBehaviour
{
	// Token: 0x06001CCC RID: 7372 RVA: 0x00156B27 File Offset: 0x00154D27
	private void Start()
	{
		this.Label.enabled = false;
	}

	// Token: 0x06001CCD RID: 7373 RVA: 0x00156B38 File Offset: 0x00154D38
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

	// Token: 0x06001CCE RID: 7374 RVA: 0x00156BB4 File Offset: 0x00154DB4
	private string FormatTime(float time)
	{
		int num = (int)time;
		int num2 = num / 60;
		int num3 = num % 60;
		float num4 = time * 1000f;
		num4 %= 1000f;
		return string.Format("{0:00}:{1:00}:{2:000}", num2, num3, num4);
	}

	// Token: 0x040033F4 RID: 13300
	public PoliceScript Police;

	// Token: 0x040033F5 RID: 13301
	public UILabel Label;

	// Token: 0x040033F6 RID: 13302
	public float Timer;
}
