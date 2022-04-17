using System;
using UnityEngine;

// Token: 0x0200043D RID: 1085
public class SpeedrunTimerScript : MonoBehaviour
{
	// Token: 0x06001D02 RID: 7426 RVA: 0x0015A293 File Offset: 0x00158493
	private void Start()
	{
		this.Label.enabled = false;
	}

	// Token: 0x06001D03 RID: 7427 RVA: 0x0015A2A4 File Offset: 0x001584A4
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

	// Token: 0x06001D04 RID: 7428 RVA: 0x0015A320 File Offset: 0x00158520
	private string FormatTime(float time)
	{
		int num = (int)time;
		int num2 = num / 60;
		int num3 = num % 60;
		float num4 = time * 1000f;
		num4 %= 1000f;
		return string.Format("{0:00}:{1:00}:{2:000}", num2, num3, num4);
	}

	// Token: 0x04003483 RID: 13443
	public PoliceScript Police;

	// Token: 0x04003484 RID: 13444
	public UILabel Label;

	// Token: 0x04003485 RID: 13445
	public float Timer;
}
