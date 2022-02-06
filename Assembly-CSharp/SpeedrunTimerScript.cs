using System;
using UnityEngine;

// Token: 0x02000436 RID: 1078
public class SpeedrunTimerScript : MonoBehaviour
{
	// Token: 0x06001CCE RID: 7374 RVA: 0x00156DC3 File Offset: 0x00154FC3
	private void Start()
	{
		this.Label.enabled = false;
	}

	// Token: 0x06001CCF RID: 7375 RVA: 0x00156DD4 File Offset: 0x00154FD4
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

	// Token: 0x06001CD0 RID: 7376 RVA: 0x00156E50 File Offset: 0x00155050
	private string FormatTime(float time)
	{
		int num = (int)time;
		int num2 = num / 60;
		int num3 = num % 60;
		float num4 = time * 1000f;
		num4 %= 1000f;
		return string.Format("{0:00}:{1:00}:{2:000}", num2, num3, num4);
	}

	// Token: 0x040033F8 RID: 13304
	public PoliceScript Police;

	// Token: 0x040033F9 RID: 13305
	public UILabel Label;

	// Token: 0x040033FA RID: 13306
	public float Timer;
}
